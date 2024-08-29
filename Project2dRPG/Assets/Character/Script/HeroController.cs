using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
[SerializeField]
    private int moveSpeed;

    [SerializeField]
    private Animator playerAnim;

    public Rigidbody2D rb;

	private HeroStatus herostatus;

	private Vector2 lastposition, nowposition;

	public float steplength=1;
   

    // Start is called before the first frame update
    void Start()
    {
		herostatus = GetComponent<HeroStatus>();
		lastposition = transform.position;
    }

    // Update is called once per frame
	void Update(){
		if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0){
			step();
		}
		else{
			stop();
		}
	}
    void step()
    {

       //playerの移動（velocityはRigidBodyの速度ベクトル、normalizedは正規化をしています：詳しく知りたい方は動画の方を確認してね）
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
		playerAnim.SetFloat("Speed",1.0f);
        //速度が0出ない時、キー入力に合わせてアニメーション用のパラメーターを更新する
        if(rb.velocity != Vector2.zero)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 & Input.GetAxisRaw("Vertical") == 0)
            {
                if(Input.GetAxisRaw("Horizontal") > 0)
                {
                    playerAnim.SetFloat("X", 1f);
					playerAnim.SetFloat("Y", 0);
                }
                else
                {
                    playerAnim.SetFloat("X", -1f);
					playerAnim.SetFloat("Y", 0);
                }
            }
            else if(Input.GetAxisRaw("Horizontal") == 0 & Input.GetAxisRaw("Vertical") != 0)
			{
				if(Input.GetAxisRaw("Vertical") > 0)
            	{
              		playerAnim.SetFloat("Y", 1);
					playerAnim.SetFloat("X", 0);
            	}
            	else
            	{
                	playerAnim.SetFloat("Y", -1);
					playerAnim.SetFloat("X", 0);
            	}
			}
			else
			{
				if(Input.GetAxisRaw("Vertical") > 0 & Input.GetAxisRaw("Horizontal") > 0)
            	{
              		playerAnim.SetFloat("Y", 1);
					playerAnim.SetFloat("X", 1);
            	}
				if(Input.GetAxisRaw("Vertical") < 0 & Input.GetAxisRaw("Horizontal") > 0)
            	{
              		playerAnim.SetFloat("Y", -1);
					playerAnim.SetFloat("X", 1);
            	}
				if(Input.GetAxisRaw("Vertical") > 0 & Input.GetAxisRaw("Horizontal") < 0)
            	{
              		playerAnim.SetFloat("Y", 1);
					playerAnim.SetFloat("X", -1);
            	}
				if(Input.GetAxisRaw("Vertical") < 0 & Input.GetAxisRaw("Horizontal") < 0)
            	{
              		playerAnim.SetFloat("Y", -1);
					playerAnim.SetFloat("X", -1);
            	}
			}
        }

		nowposition = transform.position;
		if(Mathf.Abs(nowposition.y-lastposition.y)>=steplength){
			herostatus.SubStepCount(1);
			lastposition=nowposition;
		}
		if(Mathf.Abs(nowposition.x-lastposition.x)>=steplength){
			herostatus.SubStepCount(1);
			lastposition=nowposition;
		}
    }

	void stop(){
		rb.velocity = new Vector2(0,0);
		playerAnim.SetFloat("Speed",0.0f);
	}
}

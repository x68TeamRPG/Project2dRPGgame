using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

	private bool Moving;
	[SerializeField]
	public int movespeed = 1;

	[SerializeField]
	private Animator playerAnim;

	public Rigidbody2D rb;

	private HeroStatus herostatus;

	private Vector3 lastposition, nowposition;

	public float steplength = 1;


	// Start is called before the first frame update
	void Awake()
	{

		DontDestroyOnLoad(this.gameObject);
	}
	void Start()
	{
		Moving = false;
		Application.targetFrameRate = 60;
		herostatus = GetComponent<HeroStatus>();
		lastposition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (!Moving)
		{
			if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
			{
				if (Input.GetAxisRaw("Horizontal") != 0 & Input.GetAxisRaw("Vertical") == 0)
				{
					if (Input.GetAxisRaw("Horizontal") > 0)
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
				else if (Input.GetAxisRaw("Horizontal") == 0 & Input.GetAxisRaw("Vertical") != 0)
				{
					if (Input.GetAxisRaw("Vertical") > 0)
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
					if (Input.GetAxisRaw("Vertical") > 0 & Input.GetAxisRaw("Horizontal") > 0)
					{
						playerAnim.SetFloat("Y", 1);
						playerAnim.SetFloat("X", 1);
					}
					if (Input.GetAxisRaw("Vertical") < 0 & Input.GetAxisRaw("Horizontal") > 0)
					{
						playerAnim.SetFloat("Y", -1);
						playerAnim.SetFloat("X", 1);
					}
					if (Input.GetAxisRaw("Vertical") > 0 & Input.GetAxisRaw("Horizontal") < 0)
					{
						playerAnim.SetFloat("Y", 1);
						playerAnim.SetFloat("X", -1);
					}
					if (Input.GetAxisRaw("Vertical") < 0 & Input.GetAxisRaw("Horizontal") < 0)
					{
						playerAnim.SetFloat("Y", -1);
						playerAnim.SetFloat("X", -1);
					}
				}
				StartCoroutine(step());
			}
		}
	}
	IEnumerator step()
	{
		Moving = true;
		lastposition = transform.position;
		float ver = Input.GetAxisRaw("Vertical") / 2;
		float hori = Input.GetAxisRaw("Horizontal") / 2;
		playerAnim.SetFloat("Speed", 1.0f);
		for (int i = 0; i < movespeed; i++)
		{
			Vector3 v = new Vector3(hori / movespeed, ver / movespeed, 0);
			transform.position += v;
			yield return null;
		}
		Moving = false;
		Vector3 pos = transform.position;
		pos.x = Mathf.Round(pos.x * 10f) / 10;
		pos.y = Mathf.Round(pos.y * 10f) / 10;
		pos.z = Mathf.Round(pos.z * 10f) / 10;
		pos.x = Mathf.Round(pos.x * 2f) / 2;
		pos.y = Mathf.Round(pos.y * 2f) / 2;
		pos.z = Mathf.Round(pos.z * 2f) / 2;
		transform.position = pos;
		stop();
		if (lastposition != transform.position)
		{
			herostatus.SubStepCount(1);
		}
	}

	void stop()
	{
		if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
		{
			playerAnim.SetFloat("Speed", 0.0f);
		}
	}

	public void SetPosition(Vector3 newPosition)
	{
		transform.position = newPosition;
  }

	public void isMoving(){
		Moving=true;
	}

	public void notMoving(){
		Moving=false;
	}
}

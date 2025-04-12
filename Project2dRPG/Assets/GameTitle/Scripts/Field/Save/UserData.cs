using UnityEngine;
using CI.QuickSave;
using CI.QuickSave.Core.Storage;
using System;
using UnityEditorInternal.VersionControl;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;



public class UserData : MonoBehaviour
{
    private static UserData instance;

    //ベストスコア

    public GameObject Hero;
    private HeroStatus herostatus;

    private String SaveFile;
    //セーブ設定
    QuickSaveSettings m_saveSettings;

    public Transform targetObject;

    public void Awake()
    {
        // QuickSaveSettingsのインスタンスを作成
        m_saveSettings = new QuickSaveSettings();
        // 暗号化の方法 
        m_saveSettings.SecurityMode = SecurityMode.Aes;
        // Aesの暗号化キー
        m_saveSettings.Password = "Password";
        // 圧縮の方法
        m_saveSettings.CompressionMode = CompressionMode.Gzip;

        herostatus = Hero.GetComponent<HeroStatus>();

        Debug.Log("シーン移動後に呼び出されました" + LoadFileName.name);
        // ここに実行したい処理を記述


        // QuickSaveReaderのインスタンスを作成



        if (DoesRootExist(LoadFileName.name) && LoadFileName.flag)
        {


            Debug.Log("loadされました");
            QuickSaveReader reader = QuickSaveReader.Create(LoadFileName.name, m_saveSettings);
            Debug.Log("StepCount=" + reader.Read<int>("StepCount"));

            // データを読み込む

            herostatus.Attack = reader.Read<int>("Attack");
            herostatus.StepCount = reader.Read<int>("StepCount");
            herostatus.Deffence = reader.Read<int>("Deffence");
            herostatus.Speed = reader.Read<int>("Speed");
            herostatus.MaxHP = reader.Read<int>("MaxHP");
            herostatus.CurrentHP = reader.Read<int>("HP");
            herostatus.CurrentMP = reader.Read<int>("MP");
            herostatus.MaxMP = reader.Read<int>("MaxMP");
            Inventory.items = reader.Read<List<Item>>("MyList");
            PlayerPrefs.SetInt("treasure0", reader.Read<int>("treasure0"));
            PlayerPrefs.SetInt("treasure1", reader.Read<int>("treasure1"));
            Debug.Log("宝箱１" + PlayerPrefs.GetInt("treasure1", 0));

            if (reader.Exists("position_x"))
            {
                float x = reader.Read<float>("position_x");
                float y = reader.Read<float>("position_y");

                targetObject.position = new Vector2(x, y);

            }
            LoadFileName.flag = false;
        }

    }


    bool DoesRootExist(string rootKey)
    {
        try
        {
            QuickSaveReader.Create(rootKey, m_saveSettings);
            Debug.Log("Root trueRoot true");
            return true; // ルートが存在する場合、ここに到達
        }
        catch (QuickSaveException)
        {
            Debug.Log("Root false");
            return false; // ルートがない場合、例外が発生

        }
    }

    public void FileNameChange(String s) { SaveFile = s; }
    /// <summary>
    /// セーブデータ読み込み
    /// </summary>
    public void Load()
    {
        //ファイルが無ければ無視
        if (QuickSaveRaw.Exists(SaveFile))
        {
            Debug.Log("returnされました");
            return;
        }

        // QuickSaveReaderのインスタンスを作成
        QuickSaveReader reader = QuickSaveReader.Create(SaveFile, m_saveSettings);
        Debug.Log("StepCount=" + reader.Read<int>("StepCount"));




        LoadFileName.name = SaveFile;
        LoadFileName.flag = true;

        if (reader.Exists("scene_name"))
        {
            string sceneName = reader.Read<string>("scene_name");

            SceneManager.LoadScene(sceneName);
        }
    }




    /// <summary>
    /// データセーブ
    /// </summary>
    public void SaveUserData()
    {
        Debug.Log("セーブデータ保存先:" + Application.persistentDataPath + SaveFile);

        // QuickSaveWriterのインスタンスを作成
        QuickSaveWriter writer = QuickSaveWriter.Create(SaveFile, m_saveSettings);

        // データを書き込む
        writer.Write("HP", herostatus.CurrentHP);
        writer.Write("StepCount", herostatus.StepCount);
        writer.Write("Attack", herostatus.Attack);
        writer.Write("Deffence", herostatus.Deffence);
        writer.Write("Speed", herostatus.Speed);
        writer.Write("MaxHP", herostatus.MaxHP);
        writer.Write("MP", herostatus.CurrentMP);
        writer.Write("MaxMP", herostatus.MaxMP);

        writer.Write("MyList", Inventory.items);

        Vector2 position = targetObject.position;
        writer.Write("position_x", position.x);
        writer.Write("position_y", position.y);

        string sceneName = SceneManager.GetActiveScene().name;
        writer.Write("scene_name", sceneName);
        // 変更を反映
        writer.Write("treasure0", PlayerPrefs.GetInt("treasure0", 0));
        writer.Write("treasure1", PlayerPrefs.GetInt("treasure1", 0));
        writer.Commit();
    }
}
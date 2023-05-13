using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float ziplamaKuvveti = 3f; //ne kadar ziplayacak kontrolu

    bool basildiMi = false; //kullanıcının inputunu algılamak için

    public string mevcutRenk;
    public Color topunRengi;
    public Color turkuaz, sari, mor, pembe;

    [SerializeField] Text scoreText, bestScoreText;


    public static int score = 0;

    int bestScore = 0;
    public GameObject halka, renkTekeri;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
        scoreText.text = "Score " + score;
        RastgeleRenkBelirle();
        bestScore = PlayerPrefs.GetInt("BestScore");   //yapılan en iyi skoru hafızada tutar.
        bestScoreText.text = "Best: " + bestScore.ToString();
    }
   


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;

        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;

        }

    }
    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();

            Destroy(collision.gameObject); // renk tekerini yok et.
            return;
        }
        if(collision.tag != mevcutRenk && collision.tag != "PuanArttirici" && collision.tag != "RenkTekeri" || collision.tag == "GameOver") //tag ile renk aynı değil ise karakter ölür.
        {
            if (bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);

            }
            score = 0; // can sistemi olucaksa entegre et yapılmıycaksa  static kaldır.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // sahneyi yeniden yükle.
        }
        if (collision.tag == "PuanArttirici")
        {
            Debug.Log("Puanci");
            score += 5;
            scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);
            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);  //halka oluşssun, x ve z aynı y 8f birim yukarda
            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 11f, transform.position.z), Quaternion.identity);
            

        }
        
                  


    }




    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4); //rastgele gelen sayıya göre renk alıcak.
        

        switch (rastgeleSayi)
        {
            case 0:
                mevcutRenk = "Turkuaz"; 
                topunRengi = turkuaz; //topun rengini mevcut renkle aynı yaptık.
                break;
            case 1:
                mevcutRenk = "Sari";
                topunRengi = sari; //topun rengini mevcut renkle aynı yaptık.
                break;
            case 2:
                mevcutRenk = "Pembe";
                topunRengi = pembe; //topun rengini mevcut renkle aynı yaptık.
                break;
            case 3:
                mevcutRenk = "Mor";
                topunRengi = mor; //topun rengini mevcut renkle aynı yaptık.
                break;

        }
        GetComponent<SpriteRenderer>().color = topunRengi;   // topun sprite renderer ında color'ı topun rengi yaptık.





    }






















}//class

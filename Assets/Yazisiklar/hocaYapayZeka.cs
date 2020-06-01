using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hocaYapayZeka : MonoBehaviour
{
    public float hız;
    public float görüşMesafesi;
    float objeyeYakınlık;
    public float beklenecekSüre;
    float kalanBeklemeSüresi;
    //gezinme
    public Transform hedef;
    bool hedefGörüldü = false;
    public Transform[] gezinmeNoktaları;
    int rastgeleHedef;
    //kaçınma
    float enYakınKaçınmaNoktasıYakınlık = Mathf.Infinity;
    Transform enYakınKaçınmaNoktası;
    public Transform[] kaçınmaNoktaları; //öne engel çıkarsa kaçınılacak noktalar
    Transform sonYönelim; //kaçınma noktasından sonra gidilecek, elde olan son bilgi
    int döngüSayısı = 0;



    void Start(){
        kalanBeklemeSüresi = beklenecekSüre;
        rastgeleHedef = Random.Range(0, gezinmeNoktaları.Length);
    }

    void Update(){
        RaycastHit2D görüldüBilgisi = Physics2D.CircleCast(transform.position, 2f, transform.right, görüşMesafesi);
        if(görüldüBilgisi.collider != null){ //görünürde bir şey varsa
            Debug.DrawLine(transform.position, görüldüBilgisi.point, Color.red);

            if(görüldüBilgisi.collider.CompareTag("engel")){
                if(Vector2.Distance(transform.position, görüldüBilgisi.collider.gameObject.transform.position) < 1f){
                    foreach(Transform kaçınmaNoktası in kaçınmaNoktaları){
                        float kaçınmaNoktasıYakınlık = (kaçınmaNoktası.position - this.transform.position).sqrMagnitude;
                        if (kaçınmaNoktasıYakınlık < enYakınKaçınmaNoktasıYakınlık) {
                            enYakınKaçınmaNoktasıYakınlık = kaçınmaNoktasıYakınlık;
                            enYakınKaçınmaNoktası = kaçınmaNoktası;
                        }
                    }
                    Debug.Log("Kaçınma Noktasına Gidiliyor!");
                    transform.position = Vector2.MoveTowards(transform.position, enYakınKaçınmaNoktası.position, hız * Time.deltaTime);
                }
                if (hedefGörüldü){
                    döngüSayısı ++;
                    sonYönelim = hedef.transform;
                    if(döngüSayısı % 2 != 0){
                        Debug.Log("Oyuncunun Son Pozisyonuna Gidiliyor!");
                        transform.position = Vector2.MoveTowards(transform.position, sonYönelim.position, hız * Time.deltaTime);
                    }
                }
            } else if(görüldüBilgisi.collider.CompareTag("oyuncu")){ //görünen şey oyuncu ise
                Debug.Log("Oyunuya Gidiliyor!");
                transform.position = Vector2.MoveTowards(transform.position, hedef.position, hız * Time.deltaTime);
                hedefGörüldü = true;
            } 
        }    
        if(!hedefGörüldü){
            transform.position = Vector2.MoveTowards(transform.position, gezinmeNoktaları[rastgeleHedef].position, hız * Time.deltaTime);
            if (Vector2.Distance(transform.position, gezinmeNoktaları[rastgeleHedef].position) < 0.2f){ //nokta ile obje arasındaki mesafe 0.2'den küçükse
                //ve eğer beklenecekSüre bittiyse
                if(kalanBeklemeSüresi <= 0){

                    //yeni bir hedef belirle
                    rastgeleHedef = Random.Range(0, gezinmeNoktaları.Length);

                    //bekleme süresini yenile
                    kalanBeklemeSüresi = beklenecekSüre;
                }
                //eğer beklenecek süre henüz bitmediyse
                else {
                    Debug.DrawLine(transform.position, transform.position + transform.right * görüşMesafesi, Color.green);
                    //beklenilecek süreden her saniye bir eksilt
                    kalanBeklemeSüresi -= Time.deltaTime;
                }
            }
        }



    }


    //eğer görüşte karakter yoksa rastgele noktalarda dolaş
    //görüşe karakter girdiyse pozisyonunu takip et
    //      görüşten çıkarsa, son görüldüğü yere git
    //          bir süre orada bekle
    //          hala görüşe girmediyse rastgele noktalarında dolaşmaya devam et
}
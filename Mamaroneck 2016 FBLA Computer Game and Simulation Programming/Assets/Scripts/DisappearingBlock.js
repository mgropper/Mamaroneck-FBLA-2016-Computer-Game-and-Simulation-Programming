#pragma strict
var What : int = 0;
var Timer : int = 0;
var MaxTimer : int = 0;
var fade: boolean = false;
var fadeout : boolean = false;
var Block : Sprite;
var Block2 : Sprite;


function Start () {

}

function Update () {
    if(What == 0){
        if(fadeout == true){
        Timer += 1;
            if(Timer >= MaxTimer){
                Timer = 0;
                if(fade == true){
                    fade == false;
                    GetComponent(SpriteRenderer).sprite = Block2;
                    GetComponent.<Collider2D>().enabled = false;
                    return;
                }
                if(fade == false){
                    fade = true;
                    GetComponent(SpriteRenderer).sprite = Block;
                    GetComponent.<Collider2D>().enabled = true;
                    return;
                }
            }
        }
    }
}

function OnCollisionEnter2D(other : Collision2D){
    if(other.gameObject.tag == "Player"){
        if(What == 1){
            fadeout = true;

        }
    }



}
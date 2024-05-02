
using UnityEngine;
public class Automat 
{
    private float x, y, width, height;
    private GameObject primitive;
    private GameObject root;
    private SpriteRenderer spriteRenderer;
    private Texture2D texture2D;
    private Rect rect;
    private Sprite sprite;
    private Color color;
    private int alive;

    public Automat(GameObject root, float x, float y, float width, float height, int alive)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.alive = alive;
        this.root = root;
    }

        
    // public void Draw(Color color)
    // {
    //     this.color = color;
    //     CreatePrimitive();
    // }

    public void Draw()
    {
        if (this.alive == 1)
        {
            this.color = Color.red;
        }
        else
        {
            this.color = Color.white;
        }
        CreatePrimitive();
    }


    private protected GameObject CreatePrimitive()
    {
        this.primitive = new GameObject();
        this.primitive.transform.SetParent(this.root.transform);
        this.primitive.transform.position = new Vector3(x, y, 0);
        this.spriteRenderer = this.primitive.AddComponent<SpriteRenderer>();
        this.spriteRenderer.color = color;
        this.texture2D = new Texture2D((int)(this.width), (int)(this.height));
        this.rect = new Rect(0, 0, this.width, this.height);
        this.sprite = Sprite.Create(this.texture2D, this.rect, new Vector2(0.5f, 0.5f), 1f);
        this.spriteRenderer.sprite = this.sprite;
        return this.primitive;
    }


    public int IsAlive()
    {
        return this.alive;
    }

    public void SetAlive()
    {
        this.alive = 1;
    }

    public void SetDead()
    {
        this.alive = 0;

    }

}

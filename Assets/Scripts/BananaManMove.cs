using UnityEngine;

public class BananaManMove : MonoBehaviour
{
    // Declaramos as variables privadas serializadas, para poder editalas desde o inspector.
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 200f; 

    // Update execútase cada fotograma.
    void Update()
    {
        // Calculamos o movemento e a rotación
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Avanzamos esas unidades por segundo independientemente dos fps con Time.deltaTime.
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Aplicamos o desplazamiento respecto á posición actual e rotamos o xogador.
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}

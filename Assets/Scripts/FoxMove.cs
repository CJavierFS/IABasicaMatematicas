using UnityEngine;

// Controla o movimiento automático de Foxy respecto a Banana Man.
// Foxy alonxase ou achégase según a distancia e intenta colocarse diante do xogador mediante un moviminto circular.

public class FoxMove : MonoBehaviour
{
    // Referencia ó transform do xogador.
    [SerializeField] private Transform bananaMan;

    // Distancias permitidas entre Foxy e Banana Man.
    [SerializeField] private float minDistance = 5f;
    [SerializeField] private float maxDistance = 7f;

    // Velocidad de desplazamiento e rotación arredor do xogador.
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 90f;

    // Margen de tolerancia para considerar que Foxy chegou á posición.
    [SerializeField] private float accuracy = 0.25f;


    // Update executase unha vez por fotograma
    void Update()
    {
        // Calculamos a distancia actual entre Foxy e Banana Man.
        float distance = (bananaMan.position - transform.position).magnitude;

        // Si Foxy está demasiado cerca, alonxase do xogador.
        if (distance < minDistance)
        {
            // Calculamos a dirección na que mira Banana MAn
            Vector3 direction = (transform.position - bananaMan.position).normalized;

            transform.LookAt(direction + transform.position);

            // Calculamos o vector de velocidad e facemos que se mova Foxy
            Vector3 velocity = direction * speed * Time.deltaTime;

            transform.position += velocity;
        }
        // Si Foxy está demasiado lonxe, acércase.
        else if (distance > maxDistance)
        {
            Vector3 direction = - (transform.position - bananaMan.position).normalized;

            transform.LookAt(bananaMan.position);

            Vector3 velocity = direction * speed * Time.deltaTime;

            transform.position += velocity;
        }
        else
        {
            // Calculamos a dirección actual
            Vector3 currentDirection = transform.position - bananaMan.position;

            // Calculamos canto pode rotar Foxy arredor de BAnana Man
            float maxRotation = rotateSpeed * Mathf.Deg2Rad * Time.deltaTime;

            // Calculamos a nova dirección, cara donde está mirando Banana Man
            Vector3 newDirection = Vector3.RotateTowards(currentDirection, bananaMan.forward, maxRotation, 0f);

            // Gardamos a posición actual
            Vector3 previousPosition = transform.position;

            // Movemos a Foxy a nova posición
            transform.position = bananaMan.position + newDirection;

            // Calculamos o ángulo hacia destino
            float angleToTarget = Vector3.Angle(newDirection, bananaMan.forward);

            // Comparamos o ángulo ca precisión
            if (angleToTarget > accuracy)
            {
                // Mira cara á dirección do movimiento mentres se recoloca.
                Vector3 movementDirection = transform.position - previousPosition;

                transform.LookAt(transform.position + movementDirection);
            }
            else
            {
                // Foxy detiense e mira cara Banana Man
                transform.LookAt(bananaMan.position);
            }
        }
    }
}

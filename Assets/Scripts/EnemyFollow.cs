using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;  // Referência ao player
    public float speed = 3f;  // Velocidade do inimigo
    public float rotationSpeed = 5f;  // Velocidade da rotação para olhar o player
    public float groundCheckDistance = 2f;  // Distância do Raycast para verificar o chão

    void Update()
    {
        // Verifica se o player foi atribuído
        if (player != null)
        {
            // Move o inimigo em direção ao player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Rotaciona a cabeça do inimigo para olhar para o player
            Quaternion targetRotation = Quaternion.LookRotation(direction);  // Obtém a rotação para olhar para o player
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);  // Rotaciona suavemente

            // Verifica a posição do tigre em relação ao chão
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
            {
                // Ajusta a posição vertical do tigre para garantir que ele não flutue
                transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
            }
        }
    }
}

using Unity.Entities;
using UnityEngine;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
                                    ComponentType.ReadOnly<MoveData>(),
                                    ComponentType.ReadOnly<Transform>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach((Entity entity, Transform transform, ref InputData inputData, ref MoveData move) =>
        {
            var pos = transform.position;
            pos += new Vector3(inputData.Move.x * move.Speed, 0, inputData.Move.y * move.Speed);
            transform.position = pos;

            Vector3 moveDirection = new Vector3(inputData.Move.x, 0, inputData.Move.y);
            if (moveDirection.magnitude > 0)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
        });
    }
}
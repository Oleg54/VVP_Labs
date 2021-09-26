using System;

namespace Labs
{
    //структура для представления точки на двухмерной плоскости
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        //статический метод для вычисления расстояния между точками
        public static float Distance(Vector2 _from, Vector2 _to)
        {
            return MathF.Sqrt(MathF.Pow((_to.x - _from.x), 2) + MathF.Pow((_to.y - _from.y), 2));
        }

        //переопределения метода преобразования в строку, для упрощенного вывода
        public override string ToString() => $"({x}, {y})";
        
    }
}
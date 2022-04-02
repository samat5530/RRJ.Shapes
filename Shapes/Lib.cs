namespace RRJ.Shapes
{
    public class UndefinedShapeException : Exception
    {
        public UndefinedShapeException(string message) : base(message)
        {

        }
    }

    public interface IShape
    {

    }
    public class Triangle : IShape
    {
        private double aSide;
        private double bSide;
        private double cSide;
        public double  ASide
        {
            get { return aSide; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Сторона не может быть меньше нуля");
                else aSide = value;
            }
        }

        public double BSide
        {
            get { return bSide; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Сторона не может быть меньше нуля");
                else bSide = value;
            }
        }

        public double CSide
        {
            get { return cSide; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Сторона не может быть меньше нуля");
                else cSide = value;
            }
        }

        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || a + c <= b || b + c <= a) throw new ArgumentException("Треугольника с такими сторонами не существует");
            else
            {
                ASide = a;
                BSide = b;
                CSide = c;
            }
        }

        public bool IsRightTriangle()
        {
            if (this.ASide > this.BSide && this.ASide > this.CSide)
            {
                if (Math.Sqrt(Math.Pow(this.BSide, 2) + Math.Pow(this.CSide, 2)) == this.ASide) return true;
                else return false;
            }

            else if (this.BSide > this.ASide && this.BSide > this.CSide)
            {
                if (Math.Sqrt(Math.Pow(this.ASide, 2) + Math.Pow(this.CSide, 2)) == this.BSide) return true;
                else return false;
            }

            else if (this.CSide > this.ASide && this.CSide > this.BSide)
            {
                if (Math.Sqrt(Math.Pow(this.ASide, 2) + Math.Pow(this.BSide, 2)) == this.CSide) return true;
                else return false;
            }
            else return false;
        }

    }

    public class Circle : IShape
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Радиус не может быть меньше нуля");
                else radius = value;
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
    }

    public class Area
    {
        public static double Compute(IShape shape)
        {
            if (shape.GetType() == typeof(Circle))
            {
                var casted = (Circle)shape;
                return Math.PI * Math.Pow(casted.Radius, 2);
            }
            if (shape.GetType() == typeof(Triangle))
            {
                var casted = (Triangle)shape;

                //Формула Герона
                double p = (casted.ASide + casted.BSide + casted.CSide) / 2;
                double result = Math.Sqrt(p * (p - casted.ASide) * (p - casted.BSide) * (p - casted.CSide));

                return result;
            }
            else throw new UndefinedShapeException("This library does not define this type of shape or the way to find area for this type of shape");
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Geometry
{
	public abstract class Body
	{
        public abstract double GetVolume();
        public abstract void Accept(IVisitor visitor);
	}

	public class Ball : Body
	{
		public double Radius { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitBall(this);
        }

        public override double GetVolume()
        {
            return 4.0 * Math.PI * Math.Pow(((Ball)this).Radius, 3) / 3;
        }
    }

	public class Cube : Body
	{
		public double Size { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCube(this);
        }

        public override double GetVolume()
        {
            return Math.Pow(((Cube)this).Size, 3);
        }
    }

	public class Cyllinder : Body
	{
		public double Height { get; set; }
		public double Radius { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitCyllinder(this);
        }

        public override double GetVolume()
        {
            var c = this as Cyllinder;
            return Math.PI * Math.Pow(c.Radius, 2) * c.Height;
        }
    }


    public interface IVisitor
    {
        void VisitBall(Ball ball);
        void VisitCube(Cube ball);
        void VisitCyllinder(Cyllinder cyllinder);
    }

    // Заготовка класса для задачи на Visitor
    public class SurfaceAreaVisitor:IVisitor
	{
		public double SurfaceArea { get; private set; }

        public void VisitBall(Ball ball)
        {
            SurfaceArea = ball.GetSurfaceArea();
        }

        public void VisitCube(Cube cube)
        {
            SurfaceArea = cube.GetSurfaceArea();
        }

        public void VisitCyllinder(Cyllinder cyllinder)
        {
            SurfaceArea = cyllinder.GetSurfaceArea();
        }
    }
	public class DimensionsVisitor:IVisitor
	{
		public Dimensions Dimensions { get; private set; }

        public void VisitBall(Ball ball)
        {
            Dimensions = ball.GetDimensions();
        }

        public void VisitCube(Cube cube)
        {
            Dimensions = cube.GetDimensions();
        }

        public void VisitCyllinder(Cyllinder cyllinder)
        {
            Dimensions = cyllinder.GetDimensions();
        }
    }
}

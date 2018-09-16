using System;

// The interface IShape defines the functionality of IShape implemented by decorator
public interface IShape 
{
   void drawing();
}

// Extension of a simple shape as Circle without anything special
public class Circle : IShape
{
    public void drawing()
    {
        Console.WriteLine("drawing from Circle");
    }
}

// Abstract decorator class - note that it implements IShape interface
public abstract class ShapeDecorator : IShape
{
    public IShape decoratedShape;
    
    public ShapeDecorator(IShape decoratedShape)
    {
        this.decoratedShape = decoratedShape;
    }  

    public virtual void drawing()
    {
        this.decoratedShape.drawing();
    }
}

// Decorator RedShapeDecorator draws Red Color Border.
// Note it extends ShapeDecorator.
public class RedShapeDecorator : ShapeDecorator
{
    public RedShapeDecorator(IShape decoratedShape) : base (decoratedShape) 
    {
    }  

    // Overriding methods defined in the abstract superclass
    public override void drawing()
    {
         base.drawing();
         RedDrawing();
    }
    
    private void RedDrawing()
    {
        Console.WriteLine( "Red color border from RedShapeDecorator" );
    }
}


public class DecoratorDesignPattern{
    
	static public void Main ()
	{
	    IShape circle = new Circle();
	    //IShape rectangle = new Rectangle();
	    IShape redCirle = new RedShapeDecorator (circle);
	   // IShape redRectangle = new RedShapeDecorator (rectangle);

      //  circle.drawing();
       // rectangle.drawing();
        redCirle.drawing();
      //  redRectangle.drawing();
            
	}
}

public abstract class GameObject : IGameObject
{
    private char charValue;
    private IMatrixPosition position;    

    protected GameObject(IMatrixPosition position, char charValue)
    {
        this.Position = position;
        this.CharValue = charValue;
    }

    public char CharValue
    {
        get { return this.charValue; }
        private set { this.charValue = value; }
    }

    public IMatrixPosition Position
    {
        get { return this.position; }
        protected set { this.position = value; }
    }    
}
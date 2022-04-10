using System.Drawing;
using System.Windows.Forms;

public class TextAndImageColumn : DataGridViewTextBoxColumn
{
    private Image imageValue;

    public TextAndImageColumn()
    {
        CellTemplate = new TextAndImageCell();
    }

    public override object Clone()
    {
        TextAndImageColumn c = base.Clone() as TextAndImageColumn;
        c.imageValue = imageValue;
        return c;
    }

    public Image Image
    {
        get
        {
            return imageValue;
        }
        set
        {
            if (Image != value)
            {
                imageValue = value;
                if (InheritedStyle != null)
                {
                    Padding inheritedPadding = InheritedStyle.Padding;
                    DefaultCellStyle.Padding = new Padding(value.Size.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
                }
            }
        }
    }
    private TextAndImageCell TextAndImageCellTemplate
    {
        get
        {
            return CellTemplate as TextAndImageCell;
        }
    }
}


public class TextAndImageCell : DataGridViewTextBoxCell
{
    private Image imageValue;
    private Size imageSize;

    public override object Clone()
    {
        TextAndImageCell c = base.Clone() as TextAndImageCell;
        c.imageValue = imageValue;
        c.imageSize = imageSize;
        return c;
    }

    public Image Image
    {
        get
        {
            if (OwningColumn == null || OwningTextAndImageColumn == null)
                return imageValue;
            else if (imageValue != null)
                return imageValue;
            else
                return OwningTextAndImageColumn.Image;
        }
        set
        {
            if (imageValue != value)
            {
                imageValue = value;
                imageSize = value.Size;

                Padding inheritedPadding = InheritedStyle.Padding;
                Style.Padding = new Padding(imageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
            }
        }
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        // Paint the base content
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        if (Image != null)
        {
            // Draw the image clipped to the cell.
            System.Drawing.Drawing2D.GraphicsContainer container = graphics.BeginContainer();
            graphics.SetClip(cellBounds);
            graphics.DrawImageUnscaled(Image, cellBounds.X, cellBounds.Y + (cellBounds.Height - imageSize.Height) / 2);
            graphics.EndContainer(container);
        }
    }

    private TextAndImageColumn OwningTextAndImageColumn
    {
        get
        {
            return OwningColumn as TextAndImageColumn;
        }
    }
}

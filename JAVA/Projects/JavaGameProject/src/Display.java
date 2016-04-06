import javax.swing.*;
import java.awt.*;

/**
 * Created by Zisov4eto on 04-Apr-16.
 */
public class Display {
    private JFrame frame;
    private Canvas canvas;

    private String tittle;
    private int width;
    private int height;

    public Display(String tittle, int width, int height) {
        this.tittle = tittle;
        this.width = width;
        this.height = height;

        createDisplay();
    }

    public Canvas getCanvas(){
        return this.canvas;
    }

    private void createDisplay() {
        frame = new JFrame(this.tittle);
        frame.setSize(this.width, this.height);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setResizable(false);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);

        canvas = new Canvas();
        canvas.setPreferredSize(new Dimension(this.width, this.height));
        canvas.setMaximumSize(new Dimension(this.width, this.height));
        canvas.setMinimumSize(new Dimension(this.width, this.height));

        frame.add(canvas);
        frame.pack();
    }
}

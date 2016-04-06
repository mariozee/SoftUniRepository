import java.awt.*;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.util.ArrayList;

/**
 * Created by Zisov4eto on 04-Apr-16.
 */
public class Game implements Runnable {
    private Display display;
    private Thread thread;
    private boolean running = false;
    private BufferStrategy bs;
    private Graphics g;
    private ArrayList<BufferedImage> actions;

    public int width;
    public int height;
    public String tittle;


    public Game(String tittle, int height, int width) {
        this.tittle = tittle;
        this.height = height;
        this.width = width;
    }


    @Override
    public void run() {
        init();

        int fps = 20;
        double timePerTick = 1000000000 / fps;
        double delta = 0;
        long now;
        long lastTime = System.nanoTime();

        while (running) {
            now = System.nanoTime();
            delta += (now - lastTime) / timePerTick;
            lastTime = now;
            if (delta >= 1){
                tick();
                render();
                delta--;
            }

        }

        stop();
    }

    int x = -1;
    int y = -1;
    int index = -1;

    private void tick() {
        index++;
        x++;
        y++;
        if (index > 5){
            index = 0;
        }
    }

    private void render() {
        bs = display.getCanvas().getBufferStrategy();
        if (bs == null) {
            display.getCanvas().createBufferStrategy(3);
            return;
        }

        g = bs.getDrawGraphics();
        //Clear Screen
        g.clearRect(0, 0, width, height);
        //Draw here!
        g.drawImage(actions.get(index), 300, 200, null);
        //End Drawing!
        bs.show();
        g.dispose();
    }

    private void init() {
        this.display = new Display(tittle, width, height);
        Assets.init();
        actions = new ArrayList<>();
        actions.add(Assets.action01);
        actions.add(Assets.action02);
        actions.add(Assets.action03);
        actions.add(Assets.action04);
        actions.add(Assets.action05);
        actions.add(Assets.action06);
    }

    public synchronized void start() {
        if (running) {
            return;
        }
        running = true;
        thread = new Thread(this);
        thread.start();
    }

    public synchronized void stop() {
        if (!running) {
            return;
        }
        running = false;
        try {
            thread.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}

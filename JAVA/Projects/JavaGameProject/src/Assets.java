import java.awt.image.BufferedImage;

/**
 * Created by Zisov4eto on 06-Apr-16.
 */
public class Assets {

    private static final int width = 184;
    private static final int height = 155;

    public static BufferedImage action01;
    public static BufferedImage action02;
    public static BufferedImage action03;
    public static BufferedImage action04;
    public static BufferedImage action05;
    public static BufferedImage action06;

    public static void init(){
        SpriteSheet sheet = new SpriteSheet(ImageLoader.loadImage("/textures/sheet.png"));
        action01 = sheet.crop(0, 0, width, height);
        action02 = sheet.crop(width, 0, width, height);
        action03 = sheet.crop(width * 2, 0, width, height);
        action04 = sheet.crop(0, height, width, height);
        action05 = sheet.crop(width, height, width, height);
        action06 = sheet.crop(width * 2, height, width, height);
    }
}

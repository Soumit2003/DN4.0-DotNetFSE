public class Main {
    public static void main(String[] args) {
        Computer myPC = new Computer.Builder("Intel i7", "16GB")
                            .setStorage("512GB SSD")
                            .setGraphicsCard("NVIDIA GTX 3060")
                            .build();

        myPC.specs();
    }
}

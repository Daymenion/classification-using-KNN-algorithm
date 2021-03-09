# classification-using-KNN-algorithm-
 CLASSIFICATION USING K-NEAREST NEIGHBORS (KNN) ALGORITHM. This project is for classifying banknotes using the KNN algorithm.  
 CLASSIFICATION USING THE NEAREST NEIGHBORS (KNN) ALGORITHM CLASSIFICATION ACCORDING TO THE NEAREST NEIGHBOR METHOD
There are various features extracted from real and fake banknote image samples. The image given through this information can be classified as real / fake. For each sample, 4 features (variance, skewness, kurtosis, entropy) information and whether real money (type) are readily available. We have data on a total of 1372 samples. Using this data, it is desirable to write an algorithm that finds out which of the two different types of images the image belongs to. Operations will be performed using image attributes instead of images.
a) Classification with kNN: Write down the algorithm (k nearest neighbor method) that determines which type a banknote belongs to. Write the kNN algorithm yourself, which determines which class (real (1) / fake (0)) it belongs to by taking the value of k as input for all properties of a user-entered banknote.

b) Banknote classification: Take the k value of the kNN algorithm you wrote as input and the 4 properties of a user-entered banknote as input, and list the properties, distances and classes of the nearest k banknotes on the screen as a table. Using the dataset whose connection is given on the previous page, estimate the type of the banknote with the kNN method and print it on the screen.

c) Measuring Success: Separate 100 data at the end of each banknote sample in the dataset as test data. Take the value of k from the user, classify each of the test data, using the method in item a and all 4 features, among the remaining 1172 sample data, make the listings in b. Compare the actual classes of the test data with the classes you predicted with kNN (print both real and predicted types / classes). Print the success rate as: the number of correctly classified banknotes / the total number of banknotes used for testing purposes in the dataset.

d) Listing: Type the code that displays the values in the data set in the memory.

Turkish description (
CLASSIFICATION USING K-NEAREST NEIGHBORS (KNN) ALGORITHM 
K EN YAKIN KOMŞU YÖNTEMİ İLE SINIFLANDIRMA 
Gerçek ve sahte banknot görüntü örneklerinden çıkarılan çeşitli öznitelikler bulunmaktadır. Bu 
bilgiler aracılığı ile verilen görüntü gerçek/sahte olarak sınıflandırılabilmektedir. Her bir örnek 
için 4’er adet özellik (varyans, çarpıklık, basıklık, entropi) bilgisi ve gerçek para olup/olmadığı 
(tür) hazır olarak verilmektedir. Tablo 1’de 6 tanesine yer verilmiştir. Elimizde toplam 1372 
adet örneğe ilişkin veriler bulunmaktadır. Bu verileri kullanarak, görüntünün iki farklı türden 
hangisine ait olduğunu bulduran bir algoritmanın yazılması istenmektedir. Görüntü yerine 
görüntü öznitelikleri kullanılarak işlemler gerçekleştirilecektir.

![image](https://user-images.githubusercontent.com/44711182/110475154-93330480-80f1-11eb-8d43-c98b8263218f.png)

a) kNN ile sınıflandırma: Bulduğumuz ancak türünü bilmediğimiz bir banknotun hangi türe 
ait olduğunu tespit eden algoritmayı (k en yakın komşu yöntemi) yazınız (hazır kNN
kullanmayınız). k değerini, kullanıcı tarafından girilebilen bir banknotun tüm özellik(ler)ini 
girdi olarak aldırarak bu yöntemle hangi sınıftan (gerçek (1) / sahte (0)) olduğunu bulduran 
kNN algoritmasını kendiniz yazınız.

kNN Yöntemi: 
Elinizdeki türü bilinmeyen banknotun özelliklerini, verisetindeki tüm kayıtlarla karşılaştırarak 
özellikleri uzaklık d (distance) formülüne göre en yakın olan k tane banknotu bulmalısınız. 
Bulduğunuz bu k tane banknotun türlerine bakarak en çok sayıda hangi türden banknot varsa 
banknotunuzu o türden sayacak ve sınıflandıracaksınız. 
A = (x1, x2,…, xm) ve B = (y1, y2,…, ym) özellik vektörleri, m özellik sayısı olmak üzere iki 
banknot (A ve B) arasındaki uzaklığı (distance) hesaplayan d(A,B) Formülü:√∑ (𝑥𝑖 − 𝑦𝑖)
𝑚 2
𝑖=1
Tablo 1’deki ikinci yani 1 numaralı banknotun özellikleri sırası ile 4.5459, 8.1674, -2.4586 ve 
-1.4621‘dir. 
Örnek olarak K değerini kullanıcı 3 girdiyse, verdiğiniz öznitelik dizisine uzaklığı en yakın (az) 
olan 3 banknotu tespit etmelisiniz. İki tanesi gerçek (1), bir tanesi de sahte (0) ise oy çokluğu 
ile banknotu gerçek olarak sınıflandıracaksınız. Eğer oy çokluğu konusunda 1’den fazla 
banknot arasında eşitlik olursa en yakın banknotun türünde sınıflandırabilirsiniz (k=1 için). 
* kNN tutorial: KNN Algorithm - Finding Nearest Neighbors - Tutorialspoint
* kNN demo: vision.stanford.edu/teaching/cs231n-demos/knn/

b) Banknot sınıflandırma: Yazdığınız kNN algoritmasının k değerini, kullanıcı tarafından 
girilebilen bir banknotun 4 adet özelliğini girdi olarak aldırarak, en yakın k adet banknotun 
özelliklerini, uzaklıklarını ve hangi sınıflardan olduklarını bir tablo olarak ekrana 
listeleyiniz. Bağlantısı önceki sayfada verilen verisetini kullanarak kNN yöntemi ile 
banknotun da türünü tahminleyiniz ve ekrana yazdırınız.

c) Başarı Ölçümü: Verisetinde her bir tür banknot örneğinin sonunda yer alan 100’er veriyi 
test verisi olarak ayırınız. k değerini kullanıcıdan aldırarak, test verilerinden herbirini, a 
maddesindeki yöntemi ve 4 özelliğin tümünü kullanarak kalan 1172 adet örnek veri üzerinden 
sınıflandırınız, b’deki listelemeleri yapınız. Test verilerinin gerçek sınıfları ile, kNN ile 
tahminlediğiniz sınıflarını karşılaştırınız (gerçek ve tahminlenen türlerin / sınıfların her ikisini 
de yazdırınız). Başarı oranını: doğru sınıflandırılan banknot sayısı / verisetinde test amaçlı kullandığınız toplam banknot 
sayısı olarak hesaplayarak yazdırınız.

d) Listeleme: Bellekteki verisetindeki değerleri görüntüleyen kodu yazınız. 

)

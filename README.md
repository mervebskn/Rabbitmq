### 1. Message Queue
Birbirinden bağımsız yazılım sistemleri arasında veri alışverişini sağlar. Asenkron davranış sergilenmesini sağlar.

### 2. Message Broker
Message queue içeren , Producer-Consumer iletişimi sağlayan sistem. RabbitMQ, Kafka, Redis message broker teknolojileridir.

**Örnek Senaryo:**
E-ticaret yazılımı ve sipariş sonrası fatura oluşturma ve mail gönderme işlemleri için farklı bir yazılım mevcut. Ödeme sonrası fatura, mail, stok güncelleme gibi işlemler için kullanıcının beklememesi adına bu görevi diğer yazılıma aktarma. Bu yazılımlar arası iletişimi sağlayıp ölçeklenebilir ortam sağlamak için message broker kullanırız.

### 3. RabbitMQ
Message Queue sistemidir, yoğun veri işleneceği zaman, asenkron süreci yöneten, ana uygulamadaki yoğunluğu minimize eden bir sistemdir.
Erlang dili ile yazılmıştır ve cloud hizmeti vardır.

- **_Exchange_** : Mesajın nasıl iletileceğinin modelini sunar. İlgili mesajı _exchange_ karşılar, belirtilen _route_ ile mesaj ilgili _kuyruğa_ iletilir.
  * _Direct Exchange_ : **_Route key_** ile belirli kuyruğa mesaj iletilir. 
  * Fanout Exchange : Exchange'de bind olan tüm _queue_'lere mesajlar iletilir. Queue isimleri dikkate alınmaz.
  * Topic Exchange : Route key'in bir kısmı ile eşleşen queue'lara mesaj iletilir.
  * Header Exchange: Route key yerıne _header_ kullanırız.

### 4. Message Acknowledgement
RabbitMQ , Consumer'a gönderilen bir mesajı , işlensin ya da işlenmesin, hemen queue'dan silinmek üzere işaretler. Bunu önlemek için Consumer'ın uyarılması gerekir. Eğer mesaj başarılı şekilde işlendiyse silinmelidir.
**_Messgae Acknowledgement_** güvenilir ve garantici bir yaklaşım sergilemeyi sağlar.


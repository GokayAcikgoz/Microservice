using MongoDB.Bson.Serialization.Attributes;

namespace Microservice.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        //Id tarafında guid kullanılması önerilir. Eşsizliği garanti altına alır. Guidleri biz belirleyecez. db belirlerse üretilen id yi almak ile uğraşırız.
        //MongoDB'de id alanını belirtir. _id MongoDB'nin varsayılan id alanıdır.
        //snow flake algoritması kullanacağız. ürettiği guidler birbirine yakın olur. ama eşsiz olur. indexleme için iyidir. performance artar.
        //id oluştururken new leyerek değil, NewId paketi ile oluşturacağız (snow flake algoritması).
        //int olarak koyduğumuz zaman indexleme kolaydır. ama guid olduğu zaman hepsi çok farklı olursa indexlemesi zorudr. snow flake birbirine çok yakın eşsiz değerler üretecek o yüzden indexleme kolay olacak.
        [BsonElement("_id")] 
        public Guid Id { get; set; }
    }
}

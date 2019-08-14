---

title: "AWS Solution Architect Sınavını Geçmek"
date: 2018-08-09T21:53:08+03:00
draft: false

description:
summary: AWS Solutions Architect Sınavı Nasıl Geçilir?
thumb: /static/AWS_Certified_Logo_SAA_1176x600_Color.png
thumbAlt: AWS_Certified_Logo_SAA_1176x600_Color.png

tags: ['aws', 'certification']

slug: aws-solution-architect-sinavini-gecmek
keywords: []
publishDate: 2018-08-09T21:53:08+03:00
taxonomies: []
weight: 0

state: "is-featured"

---

Bilge Adam Kurumsalda yaklaşık altı ay önce başlayan ve devam eden dönüşümün önemli adımlarından
AWS sertifika sürecimin ilk adımını 1000 puan üzerinden 900 alarak tamamladım.

Benden önce sertifika alanlar olduğu gibi sonrası da gelecek. Sizlere kısaca sınava hazırlanma süreci
ve sınav tecrübemi aktarmaya çalışarak, sertifika almaya teşvik etmeyi ve hazırlananlara yol göstermeyi
düşünüyorum.

## Sınav Hakkında

Sınavın adı AWS Solutions Architect - Associate, kodu `SAA-C01`. AWS bu sınavı Şubat 2018 tarihinde
yayınlamış. Önceki sınavın detaylı olduğu ve Solution Architect için uygun olmadığın söyleniyor.
AWS servislerinin kullanım alanlarını öğretme ve çözüm mimarı yetiştirme konusunda başarılı bir sınav
olduğunu düşünüyorum.

Ayrıca sınavın eski sınava göre zor olmadığı söyleniyor. Belli kavramları, hizmetler arasındaki
farkları oturttuğunuzda çok da zorlanacağınızı zannetmiyorum.

## Nasıl Çalıştım

A Cloud Guru'nun  Udemy üzerindeki eğitim setini satın alarak başladık. Başladık diyorum, şirkette
bu işe gönüllü kişilerle başladık. İlk zamanlar mesaiden günde yarım saat, sonra bir buçuk ay ise günde
bir buçuk saat şirketin bize sağladığı özel saatlerde sınava hep beraber hazırlandık.

- Eğitim Videoları: [*AWS Certified Solutions Architect - Associate 2018, Ryan Kroonenburg, Faye Ellis*](https://www.udemy.com/aws-certified-solutions-architect-associate/)
- Deneme sınavları: [*AWS Certified Solutions Architect Associate Practice Exams, Jon Bonso*](https://www.udemy.com/aws-certified-solutions-architect-associate-amazon-practice-exams/)

Her iki kurs da verdiğiniz paraya kuruşuna kadar değer.

## Müfredat

- S3, Glacier, DynamoDB, DynamoDB DAX, RDS, EBS, Redshift, Elastic cache.

S3 Read after write consistency, eventual consistency. RDS Encryption, EBS
snapshot. EBS'i farklı regiona taşımak.

Elastic cache ve DynamoDB arasındaki farklar.

RDS ile Redshift'i ayıran fark.

Glacier ve kullanım alanları, RDS read replica, RDS high availability.

- EC2, Lambda, ECS, Elastic Beanstalk

Lambda ve kullanım alanları, Elastic Beanstalk kullanım alanları.
AutoScaling (scheduled, reactive). Reserved ve On Demand EC2 Instance arasındaki farklar.

EC2 makinelerine IAM Role atamak

- VPC, Networking

Network Access Control List ve Security Group arasındaki farklar, NAT Instance ve NAT Gateway ne işe 
yarar, VPC endpoint nedir. Database network topolijisi.

- KMS, RDS Encryption, S3 Client Side/Server Side Encryption

- SQS

SQS ve kullanım alanları. SQS FIFO performans limitleri.

- Route53

Route53 multi region high availabilty, Route53 health checks.
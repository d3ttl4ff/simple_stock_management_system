-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: main
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `Id` char(36) NOT NULL,
  `StockCode` varchar(50) NOT NULL,
  `ItemName` varchar(255) NOT NULL,
  `Quantity` int NOT NULL,
  `Date` text NOT NULL,
  `Note` text,
  PRIMARY KEY (`Id`,`StockCode`),
  UNIQUE KEY `StockCode` (`StockCode`),
  KEY `ItemName` (`ItemName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES ('01f488af-e159-40a0-9a74-18630117ffd9','ITM002','Dark Souls II',150,'23/09/2023 22:34','Explore a cursed land.'),('2eb75b61-e67d-4e44-b2d6-29f53e755a88','ITM020','Elden Ring',850,'23/09/2023 22:42','Venture into a mysterious fantasy world.'),('2f16f6d0-1745-437f-8be4-50efe3bd21fd','ITM012','Hades',1800,'23/09/2023 22:39','Descend into the roguelike underworld.'),('3d416cb3-fc18-4375-b0ea-c8d6f14ba8d9','ITM019','Age of Empires II',100,'23/09/2023 22:42','Lead armies through history.'),('492e4af6-689f-4dd3-bf2e-7f31532b33b8','ITM008','Baldur\'s Gate III',800,'23/09/2023 22:37','Immerse in D&D\'s rich world.'),('6af889eb-c759-4cda-a21b-19f972405e01','ITM007','Dragon\'s Dogma',500,'23/09/2023 22:36','mbark on a grand fantasy adventure.'),('6ec3df89-8997-4201-91f5-90bb00d621f8','ITM004','Bloodborne',4800,'23/09/2023 22:35','Hunt horrific beasts at night.'),('73baf82c-6c41-4b53-a379-ef4441c164d3','ITM005','Sekiro: Shadows Die Twice',2500,'23/09/2023 22:35','Master shinobi skills for revenge.'),('7a0fd976-a806-4e79-b846-fee7c1faa7db','ITM011','Frostpunk',200,'23/09/2023 22:39','Lead a city through a frozen apocalypse.'),('7b9d3752-3265-4d2f-bd82-11c0bd9752bd','ITM016','God of War',3000,'23/09/2023 22:40','Embark on a mythological quest.'),('8f3b3225-22f7-4b13-8538-795962513b9b','ITM009','Cyberpunk 2077',450,'23/09/2023 22:38','Dive into a dystopian future.'),('90c13e38-1dde-45f6-ad9f-beda2feaafe0','ITM001','Dark Souls I',1050,'23/09/2023 22:34','Prepare for brutal challenges.'),('a5fc320b-6aa2-4241-87e7-aacf51fed722','ITM006','Red Dead Redemption II',1200,'23/09/2023 22:36','Live the outlaw life in the Wild West.'),('ad32b029-8990-4d20-9be7-5c76a835fce9','ITM018','Hollow Knight',800,'23/09/2023 22:42','Descend into a haunting world.'),('bc28f661-eb0d-4788-916f-14f2159ef3be','ITM010','Stardew Valley',4500,'23/09/2023 22:39','Escape to peaceful farm life.'),('cfd71fba-909c-471d-a808-b109dd12ab09','ITM003','Dark Souls III',6000,'23/09/2023 22:35','Embrace the darkness, face tough foes.'),('e23a649b-ec63-4536-9171-78aefa3fc0f8','ITM013','The Witcher III - Wild Hunt',7000,'23/09/2023 22:39','Join Geralt\'s monster-hunting journey.'),('ec6a054e-0570-4236-9ade-b0e62f6083b9','ITM017','Hogwarts Legacy',200,'23/09/2023 22:41','Attend Hogwarts, uncover magic.');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction_log`
--

DROP TABLE IF EXISTS `transaction_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction_log` (
  `Id` char(36) NOT NULL,
  `StockCode` varchar(50) NOT NULL,
  `ItemName` varchar(255) NOT NULL,
  `Type` text NOT NULL,
  `QuantityStats` text NOT NULL,
  `NewQuantity` int NOT NULL,
  `Date` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction_log`
--

LOCK TABLES `transaction_log` WRITE;
/*!40000 ALTER TABLE `transaction_log` DISABLE KEYS */;
INSERT INTO `transaction_log` VALUES ('14e7d9b6-175b-406d-8a28-c3394cb38c01','ITM016','God of War','Item added','Added 3000 item(s)',3000,'23/09/2023 22:40'),('18c92010-6172-4686-97ee-3b0373cfbdb8','ITM015','Horizon Zero Dawn','Item added','Added 900 item(s)',900,'23/09/2023 22:40'),('216ccb60-2304-405f-90ed-56a9535a4012','ITM021','Batman: Arkham Knight','Item added','Added 250 item(s)',250,'23/09/2023 23:15'),('2635ac16-bc51-4e74-b144-69227b6364e4','ITM004','Bloodborne','Item added','Added 4800 item(s)',4800,'23/09/2023 22:35'),('2788e50a-ca36-4dd6-b6f5-4fa2865a39bd','ITM017','Hogwarts Legacy','Quantity removed','Removed 100 item(s)',200,'23/09/2023 22:43'),('2f73e2c5-ae23-4c13-942b-b09673e6d25b','ITM010','Stardew Valley','Item added','Added 4500 item(s)',4500,'23/09/2023 22:39'),('308c78b6-c2ca-4b27-a130-3a5e5e61e4c3','ITM002','Dragon Slayer Sword','Item deleted','-',0,'23/09/2023 22:27'),('36597563-8c3a-4e0e-bc4d-cbae8f33b9d8','ASD','asd','Item deleted','-',0,'27/09/2023 11:54'),('3b348b0e-af00-4b40-ada1-5404a5d8c4b4','ITM003','Dark Souls III','Item added','Added 5000 item(s)',5000,'23/09/2023 22:35'),('4020a0a6-1a4e-4d1b-8260-9887c49c4fce','ITM012','Hades','Item added','Added 1800 item(s)',1800,'23/09/2023 22:39'),('4366a2dd-8ee2-490d-824d-11b98d2e66d0','ITM009','Cyberpunk 2077','Item added','Added 450 item(s)',450,'23/09/2023 22:38'),('4a1f821d-06e2-45d0-bf36-4ade3a9f642d','ITM015','Horizon Zero Dawn','Item deleted','-',0,'23/09/2023 22:43'),('4acd3303-04a7-46cb-b868-f62b93e12f1d','ITM002','Dark Souls II','Item added','Added 150 item(s)',150,'23/09/2023 22:34'),('57269fe3-5253-41ad-8a68-88d167f6deb8','ITM011','Frostpunk','Item added','Added 200 item(s)',200,'23/09/2023 22:39'),('59cb77b5-1a8c-4f50-9bfc-f0589fbd0400','ITM014','Dishonored','Item added','Added 650 item(s)',650,'23/09/2023 22:40'),('6d3862e3-8994-4b8a-903c-e1040b5c8af2','ITM013','The Witcher III - Wild Hunt','Item added','Added 7000 item(s)',7000,'23/09/2023 22:39'),('7034c498-2741-42b5-aa7f-865d6f1ff084','ITM021','Batman: Arkham Knight','Quantity removed','Removed 500 item(s)',-250,'23/09/2023 23:15'),('815ad80c-0f5d-4b18-b757-a57be7f35ec7','ITM014','Dishonored','Item deleted','-',0,'23/09/2023 22:43'),('817e0043-f507-48cd-85d6-909d7f316639','ASD','asd','Item added','Added 890 item(s)',890,'27/09/2023 11:53'),('94ea4b3a-3b0c-43df-9e2e-53073708f0be','ITM017','Hogwarts Legacy','Item added','Added 300 item(s)',300,'23/09/2023 22:41'),('9855bbe8-6203-478d-b707-ce3072b6b62a','ASD','asd','Quantity added','Added 100 item(s)',980,'27/09/2023 11:54'),('99c0580a-97fc-44ff-abb0-59b4c69ec241','ITM006','Red Dead Redemption II','Item added','Added 1200 item(s)',1200,'23/09/2023 22:36'),('9bc032eb-97fa-49ed-827a-3a6153d03b46','ITM019','Age of Empires II','Item added','Added 100 item(s)',100,'23/09/2023 22:42'),('a4ec1194-e15f-4ead-907c-0bb285e012ee','ITM018','Hollow Knight','Item added','Added 350 item(s)',350,'23/09/2023 22:42'),('a7ef0cba-e7d5-4b58-a257-1a8e75722525','ITM020','Elden Ring','Item added','Added 850 item(s)',850,'23/09/2023 22:42'),('a915908c-3446-4d7d-9ef6-2186adfac798','ITM005','Sekiro: Shadows Die Twice','Item added','Added 2500 item(s)',2500,'23/09/2023 22:35'),('a9495d26-c4dc-4098-8424-08b74e63d4e3','ITM003','Cyberpunk 2077','Item added','Added 5000 item(s)',5000,'23/09/2023 22:21'),('b232fbbb-6a1e-4cd5-9a98-5de5f4ae6622','ASD','','Item deleted','-',0,'27/09/2023 11:54'),('b2fb271e-d7a6-4cac-b3a8-7f2d44ed3778','ITM002','Dragon Slayer Sword','Item added','Added 400 item(s)',400,'23/09/2023 22:20'),('b569a639-6bf8-4a22-acf4-d402057c95a0','ITM007','Dragon\'s Dogma','Item added','Added 500 item(s)',500,'23/09/2023 22:36'),('ba66dd60-9fc8-46f9-9ef8-6ac4a2a7f5bb','ITM001','Galactic Adventure','Item added','Added 120 item(s)',120,'23/09/2023 22:19'),('bd2eb3b8-3e25-4727-bbaa-d7ebcc7798df','ASD','asd','Quantity removed','Removed 10 item(s)',880,'27/09/2023 11:53'),('c07720e4-4a96-470d-94f3-588e6c50af5d','ITM008','Baldur\'s Gate III','Item added','Added 800 item(s)',800,'23/09/2023 22:37'),('cdd9818c-464d-4d63-a0bd-a269189ee8f1','ITM021','','Item deleted','-',0,'23/09/2023 23:15'),('d1cadf3a-02ec-4a52-a3ce-601dbdb9cfdc','ITM002','Dark Souls II','Quantity added','Added 80 item(s)',230,'23/09/2023 22:37'),('f39712b1-ea77-4a03-ad4e-456e468ad779','ITM015','','Item deleted','-',0,'23/09/2023 22:43'),('f9dda190-94a5-4d04-80e6-f15d38b02c15','ITM003','Dark Souls III','Quantity added','Added 1000 item(s)',6000,'23/09/2023 22:43'),('fcc39d08-e468-4e50-b01e-ad44812b43df','ITM018','Hollow Knight','Quantity added','Added 450 item(s)',800,'23/09/2023 22:43'),('fd44b7fb-6875-4275-90d8-7991f2e393c0','ITM001','Dark Souls I','Item added','Added 750 item(s)',750,'23/09/2023 22:34');
/*!40000 ALTER TABLE `transaction_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `Id` char(36) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('c7919907-4e37-11ee-8795-00d86184c307','admin','admin','Admin','Admin','admin@gmail.com');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-27 18:07:47

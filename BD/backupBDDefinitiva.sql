/*
SQLyog Community v13.1.9 (64 bit)
MySQL - 10.4.24-MariaDB : Database - bddefinitiva
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bddefinitiva` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `bddefinitiva`;

/*Table structure for table `calificacion` */

DROP TABLE IF EXISTS `calificacion`;

CREATE TABLE `calificacion` (
  `IDCalificacion` int(11) NOT NULL,
  `Nivel` varchar(255) NOT NULL,
  PRIMARY KEY (`IDCalificacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `calificacion` */

insert  into `calificacion`(`IDCalificacion`,`Nivel`) values 
(1,'basico'),
(2,'principiante'),
(3,'entusiasta'),
(4,'emedio'),
(5,'avanzado');

/*Table structure for table `cursos` */

DROP TABLE IF EXISTS `cursos`;

CREATE TABLE `cursos` (
  `IDCurso` int(11) NOT NULL AUTO_INCREMENT,
  `ProfesorAsignado` int(11) NOT NULL,
  `NombreCurso` varchar(255) NOT NULL,
  `Area` int(11) NOT NULL,
  `Disponibilidad` int(11) NOT NULL,
  `Dificultad` int(11) NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL,
  PRIMARY KEY (`IDCurso`),
  KEY `fk1` (`ProfesorAsignado`),
  KEY `fk2` (`Area`),
  KEY `fk3` (`Disponibilidad`),
  KEY `fk4` (`Dificultad`),
  CONSTRAINT `fk1` FOREIGN KEY (`ProfesorAsignado`) REFERENCES `profesores` (`IDProfesor`),
  CONSTRAINT `fk2` FOREIGN KEY (`Area`) REFERENCES `tipocurso` (`IDTipoCurso`),
  CONSTRAINT `fk3` FOREIGN KEY (`Disponibilidad`) REFERENCES `disponibilidadcurso` (`IDDisponibilidad`),
  CONSTRAINT `fk4` FOREIGN KEY (`Dificultad`) REFERENCES `calificacion` (`IDCalificacion`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

/*Data for the table `cursos` */

insert  into `cursos`(`IDCurso`,`ProfesorAsignado`,`NombreCurso`,`Area`,`Disponibilidad`,`Dificultad`,`FechaInicio`,`FechaFin`) values 
(1,3,'Curso Excel Formulas y Tablas',1,1,3,'2022-11-21 03:11:58','2023-01-04 03:12:01'),
(2,1,'Personal Media Training',2,1,4,'2023-01-06 03:12:08','2023-05-31 03:12:14'),
(3,2,'SQL desde cero',3,1,2,'2022-11-21 03:12:55','2023-02-14 03:12:57'),
(4,4,'Postreria para principiantes',4,1,1,'2022-11-21 03:13:30','2023-03-09 03:13:32');

/*Table structure for table `cursousuario` */

DROP TABLE IF EXISTS `cursousuario`;

CREATE TABLE `cursousuario` (
  `IDRegistro` int(11) NOT NULL AUTO_INCREMENT,
  `IDusuariox` int(11) NOT NULL,
  `IDcursox` int(11) NOT NULL,
  PRIMARY KEY (`IDRegistro`),
  KEY `qweqwe` (`IDusuariox`),
  KEY `asdasdasd` (`IDcursox`),
  CONSTRAINT `asdasdasd` FOREIGN KEY (`IDcursox`) REFERENCES `cursos` (`IDCurso`),
  CONSTRAINT `qweqwe` FOREIGN KEY (`IDusuariox`) REFERENCES `usuarios` (`IDUser`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;

/*Data for the table `cursousuario` */

insert  into `cursousuario`(`IDRegistro`,`IDusuariox`,`IDcursox`) values 
(1,1,1),
(2,1,4),
(3,3,3),
(9,4,4);

/*Table structure for table `disponibilidadcurso` */

DROP TABLE IF EXISTS `disponibilidadcurso`;

CREATE TABLE `disponibilidadcurso` (
  `IDDisponibilidad` int(11) NOT NULL,
  `Estado` varchar(255) NOT NULL,
  PRIMARY KEY (`IDDisponibilidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `disponibilidadcurso` */

insert  into `disponibilidadcurso`(`IDDisponibilidad`,`Estado`) values 
(0,'No Disponible'),
(1,'Libre');

/*Table structure for table `profesores` */

DROP TABLE IF EXISTS `profesores`;

CREATE TABLE `profesores` (
  `IDProfesor` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  PRIMARY KEY (`IDProfesor`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

/*Data for the table `profesores` */

insert  into `profesores`(`IDProfesor`,`Name`,`Apellido`) values 
(1,'Jose','Carrion'),
(2,'Luis','Penia'),
(3,'Ernesto','Cuadros'),
(4,'Jhony','Arcela');

/*Table structure for table `tipocurso` */

DROP TABLE IF EXISTS `tipocurso`;

CREATE TABLE `tipocurso` (
  `IDTipoCurso` int(11) NOT NULL,
  `Descripcion` varchar(255) NOT NULL,
  PRIMARY KEY (`IDTipoCurso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `tipocurso` */

insert  into `tipocurso`(`IDTipoCurso`,`Descripcion`) values 
(1,'Ciencias'),
(2,'Humanidades'),
(3,'IT'),
(4,'Gastronomia');

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

CREATE TABLE `usuarios` (
  `IDUser` int(11) NOT NULL AUTO_INCREMENT,
  `Nickname` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`IDUser`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

/*Data for the table `usuarios` */

insert  into `usuarios`(`IDUser`,`Nickname`,`Password`) values 
(1,'user1','xd'),
(2,'user2','qwe'),
(3,'user3','pass'),
(4,'user6','help');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

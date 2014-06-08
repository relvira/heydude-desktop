/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50524
Source Host           : localhost:3306
Source Database       : chat_project

Target Server Type    : MYSQL
Target Server Version : 50524
File Encoding         : 65001

Date: 2014-03-06 17:28:19
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `uid` varchar(50) NOT NULL,
  `email` varchar(70) NOT NULL,
  `full_name` varchar(150) NOT NULL,
  `password` varchar(350) NOT NULL,
  `profile_img` varchar(255) DEFAULT NULL,
  `user_status` varchar(140) DEFAULT '',
  PRIMARY KEY (`id`),
  KEY `id_uid` (`id`,`uid`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', 'ret', 'relviratellez@gmail.com', 'Rafael de Elvira Téllez', '67023cda456b9844abf8a9a3992799093bbfb69f', 'raffhfghjfyj.png', 'bored');
INSERT INTO `user` VALUES ('2', 'manu', 'manu@joyfe.es', 'Manuel Mangas', 'manu', 'gonzalolo.png', 'Programando');
INSERT INTO `user` VALUES ('3', 'lolo', 'lolo@joyfe.es', 'lolo martinez', 'lolo', 'raffhfghjfyj.png', 'jugando a la play');
INSERT INTO `user` VALUES ('4', 'pepe', 'pepe@joyfe.es', 'pepe fernandez', 'pepe', 'gonzalolo.png', 'a peras');
INSERT INTO `user` VALUES ('9', 'asdf', 'asdf@asdf.com', 'asdf asdf', '2d8d596a0b97569f9226a8c33ed9c6dbc8d88120', null, '');
INSERT INTO `user` VALUES ('10', 'kkkkkkkkkk', 'kkkkk@kkkkk.com', 'rgdfsgdtsgthgf', 'a16358be6e2306b153b1f071477e68837266075e', null, '');
INSERT INTO `user` VALUES ('11', 'gonzalo', 'gonza@joyfe.es', 'gonzalo garcia', 'eaa8094a8c1738b06f5190f87c81cb0ce482a4db', null, '');
INSERT INTO `user` VALUES ('12', 'jesus', 'jesus@asdf.com', 'jesus fernandez', '8d5004c9c74259ab775f63f7131da077814a7636', null, '');
INSERT INTO `user` VALUES ('13', 'gonzalolo', 'gonza@summa.es', 'Gonzalito garcia', 'a214b952791c27395d0e19d3d72ac52a89963ba8', 'gonzalolo.png', '');
INSERT INTO `user` VALUES ('14', 'quejjabali', 'alex@pipa.com', 'alex delafont', '60c6d277a8bd81de7fdde19201bf9c58a3df08f4', 'quejjabali.png', '');
INSERT INTO `user` VALUES ('15', 'nueovmano', 'manu@mangas.con', 'manu mangas', '158873d90a7ef40f3637a222b7329c09d0222554', 'nueovmano.jpg', '');
INSERT INTO `user` VALUES ('16', 'federico', 'feder@joyfe.es', 'fede fedeee', 'a6979dc879a84b82499ca8719c46bf4f7ff03b70', 'federico.png', '');
INSERT INTO `user` VALUES ('17', 'manolo', 'manolo@joyfe.es', 'manoleteee', '0d18e2b6d68973f0f02c17c97e4765f716eca440', 'profile-default.jpg', '');
INSERT INTO `user` VALUES ('18', 'quienseas', 'rafaeollll@sdfsdf.com', 'quiensaskajd', '67023cda456b9844abf8a9a3992799093bbfb69f', 'profile-default.jpg', '');
INSERT INTO `user` VALUES ('19', 'tere', 'tere@joyfe.es', 'tere martinez', 'c5374bc4e204c0a7b0aaff3ea66b1fcb1dcc97ab', 'tere.png', '');
INSERT INTO `user` VALUES ('20', 'paco', 'paco@joyfe.es', 'paco paco', '1267ea54d8dc193b000d4a86487c7d38b7a55e43', 'profile-default.jpg', '');
INSERT INTO `user` VALUES ('21', 'testasdf', 'sdfads@asfsdf.com', 'asdfasdf', '3da541559918a808c2402bba5012f6c60b27661c', 'profile-default.jpg', '');
INSERT INTO `user` VALUES ('22', '', '', '', '', null, '');

-- ----------------------------
-- Table structure for user_friends
-- ----------------------------
DROP TABLE IF EXISTS `user_friends`;
CREATE TABLE `user_friends` (
  `friend_of` int(11) NOT NULL,
  `friend_to` int(11) NOT NULL,
  PRIMARY KEY (`friend_of`,`friend_to`),
  UNIQUE KEY `FRIENDS` (`friend_to`,`friend_of`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user_friends
-- ----------------------------
INSERT INTO `user_friends` VALUES ('0', '0');
INSERT INTO `user_friends` VALUES ('1', '2');
INSERT INTO `user_friends` VALUES ('1', '3');
INSERT INTO `user_friends` VALUES ('1', '20');
INSERT INTO `user_friends` VALUES ('2', '1');
INSERT INTO `user_friends` VALUES ('3', '1');
INSERT INTO `user_friends` VALUES ('4', '1');

-- ----------------------------
-- Table structure for user_notifications
-- ----------------------------
DROP TABLE IF EXISTS `user_notifications`;
CREATE TABLE `user_notifications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL COMMENT 'Destination of this notification',
  `notificator_id` int(11) NOT NULL COMMENT 'Who is sending this notification',
  `action` enum('friend','pending_msg') NOT NULL COMMENT 'Notification action',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user_notifications
-- ----------------------------

-- ----------------------------
-- Table structure for user_pending_messages
-- ----------------------------
DROP TABLE IF EXISTS `user_pending_messages`;
CREATE TABLE `user_pending_messages` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL COMMENT 'Who is recieving this notification',
  `notificator_id` int(11) NOT NULL COMMENT 'Who is sending this notification',
  `message` varchar(500) NOT NULL COMMENT 'Pending message content',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of user_pending_messages
-- ----------------------------

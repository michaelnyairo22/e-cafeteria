/*
MySQL Data Transfer
Source Host: localhost
Source Database: e-cafeteria
Target Host: localhost
Target Database: e-cafeteria
Date: 01/07/2011 13:28:00
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for app_settings
-- ----------------------------
DROP TABLE IF EXISTS `app_settings`;
CREATE TABLE `app_settings` (
  `cafeteria_name` varchar(255) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for booking
-- ----------------------------
DROP TABLE IF EXISTS `booking`;
CREATE TABLE `booking` (
  `booking_id` int(11) NOT NULL AUTO_INCREMENT,
  `booking_name` varchar(100) DEFAULT NULL,
  `booking_date` date DEFAULT NULL,
  `booking_time` time DEFAULT NULL,
  `booking_tel` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`booking_id`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for emp_status
-- ----------------------------
DROP TABLE IF EXISTS `emp_status`;
CREATE TABLE `emp_status` (
  `emp_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_status_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`emp_status_id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for employee
-- ----------------------------
DROP TABLE IF EXISTS `employee`;
CREATE TABLE `employee` (
  `emp_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_title` varchar(50) DEFAULT NULL,
  `emp_firstname` varchar(50) DEFAULT NULL,
  `emp_lname` varchar(50) DEFAULT NULL,
  `nickname` varchar(255) DEFAULT NULL,
  `emp_sex` int(11) DEFAULT NULL,
  `emp_status` int(11) DEFAULT NULL,
  `emp_image` varchar(255) DEFAULT NULL,
  `emp_birthday` datetime DEFAULT NULL,
  `emp_hiredate` datetime DEFAULT NULL,
  `emp_position` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`emp_id`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for food_order
-- ----------------------------
DROP TABLE IF EXISTS `food_order`;
CREATE TABLE `food_order` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_date` datetime DEFAULT NULL,
  `zone_id` varchar(1) DEFAULT NULL,
  `table_id` int(11) DEFAULT NULL,
  `remark` varchar(200) DEFAULT NULL,
  `price` double DEFAULT '0',
  `discount` double DEFAULT '0',
  `order_status` int(11) DEFAULT '1',
  `order_billno` varchar(255) DEFAULT NULL,
  `billing_datetime` datetime DEFAULT NULL,
  PRIMARY KEY (`order_id`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for food_order_detail
-- ----------------------------
DROP TABLE IF EXISTS `food_order_detail`;
CREATE TABLE `food_order_detail` (
  `order_food_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_food_id` int(11) NOT NULL DEFAULT '0',
  `order_detail_menu_id` varchar(255) DEFAULT NULL,
  `order_detail_price` int(11) DEFAULT NULL,
  `order_detail_qty` int(11) DEFAULT '1',
  `order_detail_discount` int(11) DEFAULT '0',
  `order_detail_total_price` int(11) DEFAULT NULL,
  `order_detail_remarks` varchar(200) DEFAULT NULL,
  `order_detail_status` int(11) DEFAULT '1',
  `order_detail_waiter` int(11) DEFAULT NULL,
  `order_datetime` datetime DEFAULT NULL,
  PRIMARY KEY (`order_food_detail_id`,`order_food_id`)
) ENGINE=MyISAM AUTO_INCREMENT=92 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for food_order_serial
-- ----------------------------
DROP TABLE IF EXISTS `food_order_serial`;
CREATE TABLE `food_order_serial` (
  `food_order_date` date NOT NULL DEFAULT '0000-00-00',
  `food_order_serial` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`food_order_date`,`food_order_serial`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for food_order_status
-- ----------------------------
DROP TABLE IF EXISTS `food_order_status`;
CREATE TABLE `food_order_status` (
  `food_order_status_id` int(11) NOT NULL,
  `food_order_status_name` varchar(255) NOT NULL,
  PRIMARY KEY (`food_order_status_id`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for menu
-- ----------------------------
DROP TABLE IF EXISTS `menu`;
CREATE TABLE `menu` (
  `menu_id` varchar(11) NOT NULL DEFAULT '0',
  `menu_name` varchar(255) DEFAULT NULL,
  `menu_price` double DEFAULT NULL,
  `menu_discount` double DEFAULT '0',
  `menu_committion` double DEFAULT '0',
  `menu_group` int(11) DEFAULT NULL,
  `menu_favoriate` varchar(1) DEFAULT 'N',
  `menu_image` varchar(200) DEFAULT NULL,
  `menu_auto` varchar(1) DEFAULT 'N',
  PRIMARY KEY (`menu_id`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for menugroup
-- ----------------------------
DROP TABLE IF EXISTS `menugroup`;
CREATE TABLE `menugroup` (
  `group_id` int(11) NOT NULL AUTO_INCREMENT,
  `group_name` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`group_id`)
) ENGINE=MyISAM AUTO_INCREMENT=14 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for order_status
-- ----------------------------
DROP TABLE IF EXISTS `order_status`;
CREATE TABLE `order_status` (
  `order_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_status_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`order_status_id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for pname
-- ----------------------------
DROP TABLE IF EXISTS `pname`;
CREATE TABLE `pname` (
  `pname` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`pname`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for sex
-- ----------------------------
DROP TABLE IF EXISTS `sex`;
CREATE TABLE `sex` (
  `sex_id` int(11) NOT NULL DEFAULT '0',
  `sex_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`sex_id`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for table_info
-- ----------------------------
DROP TABLE IF EXISTS `table_info`;
CREATE TABLE `table_info` (
  `zone_no` varchar(1) NOT NULL DEFAULT 'A',
  `tableno` varchar(2) NOT NULL,
  `order_no` varchar(50) DEFAULT NULL,
  `bookingname` varchar(200) DEFAULT 'ลูกค้าทั่วไป',
  `totalcustomer` int(11) NOT NULL DEFAULT '0',
  `totalprice` double DEFAULT '0',
  `table_status` int(11) DEFAULT '1',
  PRIMARY KEY (`zone_no`,`tableno`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for table_settings
-- ----------------------------
DROP TABLE IF EXISTS `table_settings`;
CREATE TABLE `table_settings` (
  `table_zone` varchar(1) NOT NULL DEFAULT '',
  `table_name` int(20) NOT NULL,
  `table_displaytext` varchar(50) DEFAULT NULL,
  `table_status` int(1) DEFAULT NULL,
  PRIMARY KEY (`table_zone`,`table_name`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for table_status
-- ----------------------------
DROP TABLE IF EXISTS `table_status`;
CREATE TABLE `table_status` (
  `table_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `table_status_name` varchar(255) NOT NULL,
  `table_status_color` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`table_status_id`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for waiter_committion
-- ----------------------------
DROP TABLE IF EXISTS `waiter_committion`;
CREATE TABLE `waiter_committion` (
  `waiter_id` int(11) DEFAULT NULL,
  `waiter_food` varchar(255) DEFAULT NULL,
  `waiter_commition` int(11) DEFAULT NULL,
  `orderdate` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for zone_settings
-- ----------------------------
DROP TABLE IF EXISTS `zone_settings`;
CREATE TABLE `zone_settings` (
  `zone_name` varchar(1) NOT NULL DEFAULT '',
  `zone_displaytext` varchar(255) DEFAULT NULL,
  `zone_status` int(1) DEFAULT '1',
  `zone_tables` int(2) DEFAULT '0',
  PRIMARY KEY (`zone_name`)
) ENGINE=MyISAM DEFAULT CHARSET=tis620;

-- ----------------------------
-- Table structure for zone_status
-- ----------------------------
DROP TABLE IF EXISTS `zone_status`;
CREATE TABLE `zone_status` (
  `zone_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `zone_status_name` varchar(255) DEFAULT NULL,
  `zone_status_color` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`zone_status_id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=tis620;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `app_settings` VALUES ('ไก่ย่าง ชบา');
INSERT INTO `emp_status` VALUES ('1', 'ทำงานอยู่');
INSERT INTO `emp_status` VALUES ('2', 'ออกแล้ว');
INSERT INTO `employee` VALUES ('0', 'คุณ', 'Default', 'System', '-', '1', '1', null, '2011-05-29 00:00:00', '2011-05-29 00:00:00', 'System');
INSERT INTO `employee` VALUES ('7', 'คุณ', 'ปิยะณัฐ', 'นิ่มขุนทด', 'ฟาร์ม', '1', '1', '', '2011-05-29 00:00:00', '2011-05-29 00:00:00', 'ไอที');
INSERT INTO `employee` VALUES ('8', 'คุณ', 'ณัฐพล', 'เสมา', 'ต้อง', '1', '1', '', '2011-05-29 00:00:00', '2011-05-29 00:00:00', 'ไอที');
INSERT INTO `food_order` VALUES ('21', '2011-06-29 22:04:40', 'A', '1', null, '20', '0', '2', '2011-06-29-1-8', '2011-06-29 22:06:43');
INSERT INTO `food_order` VALUES ('29', '2011-06-29 23:04:19', 'A', '1', null, '70', '0', '1', '', null);
INSERT INTO `food_order` VALUES ('26', '2011-06-29 22:44:02', 'A', '1', null, '70', '0', '2', '2011-06-29-16', '2011-06-29 22:55:43');
INSERT INTO `food_order` VALUES ('27', '2011-06-29 22:52:20', 'B', '12', null, '70', '0', '1', '2011-06-29-14', null);
INSERT INTO `food_order` VALUES ('28', '2011-06-29 22:53:22', 'C', '1', null, '70', '0', '2', '2011-06-29-15', '2011-06-29 22:53:37');
INSERT INTO `food_order` VALUES ('30', '2011-06-30 22:44:16', 'A', '2', null, '70', '0', '1', '', null);
INSERT INTO `food_order_detail` VALUES ('71', '27', '80', '20', '1', '0', '20', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('72', '27', '81', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('73', '27', '82', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('74', '28', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('41', '21', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:04:40');
INSERT INTO `food_order_detail` VALUES ('42', '21', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:04:40');
INSERT INTO `food_order_detail` VALUES ('70', '27', '79', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('69', '27', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('68', '27', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:52:20');
INSERT INTO `food_order_detail` VALUES ('67', '26', '82', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('66', '26', '81', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('65', '26', '80', '20', '1', '0', '20', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('64', '26', '79', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('63', '26', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('62', '26', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:44:02');
INSERT INTO `food_order_detail` VALUES ('75', '28', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('76', '28', '79', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('77', '28', '80', '20', '1', '0', '20', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('78', '28', '81', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('79', '28', '82', '10', '1', '0', '10', null, '1', '0', '2011-06-29 22:53:22');
INSERT INTO `food_order_detail` VALUES ('80', '29', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('81', '29', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('82', '29', '79', '10', '1', '0', '10', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('83', '29', '80', '20', '1', '0', '20', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('84', '29', '81', '10', '1', '0', '10', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('85', '29', '82', '10', '1', '0', '10', null, '1', '0', '2011-06-29 23:04:19');
INSERT INTO `food_order_detail` VALUES ('86', '30', '77', '10', '1', '0', '10', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_detail` VALUES ('87', '30', '78', '10', '1', '0', '10', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_detail` VALUES ('88', '30', '79', '10', '1', '0', '10', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_detail` VALUES ('89', '30', '80', '20', '1', '0', '20', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_detail` VALUES ('90', '30', '81', '10', '1', '0', '10', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_detail` VALUES ('91', '30', '82', '10', '1', '0', '10', null, '1', '0', '2011-06-30 22:44:16');
INSERT INTO `food_order_serial` VALUES ('2011-06-21', '16');
INSERT INTO `food_order_serial` VALUES ('2011-06-28', '16');
INSERT INTO `food_order_serial` VALUES ('2011-06-29', '16');
INSERT INTO `food_order_status` VALUES ('1', 'รออาหาร');
INSERT INTO `food_order_status` VALUES ('2', 'ได้ครบแล้ว');
INSERT INTO `menu` VALUES ('0100', 'ตำไทย', '35', '0', '0', '11', 'N', '', 'N');
INSERT INTO `menu` VALUES ('0101', 'ตำปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0102', 'ตำไทยปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0103', 'ตำปลาร้า', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0104', 'ตำปลาร้าปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0105', 'ตำซั่วไทย', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0106', 'ตำซั่วไทยปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0107', 'ตำซั่วปลาร้า', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0108', 'ตำซั่วปลาร้าปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0109', 'ตำซั่วปู', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0200', 'ตำมะม่วงไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0201', 'ตำมะม่วงปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0202', 'ตำมะม่วงไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0203', 'ตำมะม่วงปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0204', 'ตำมะม่วงปูปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0205', 'ตำซั่วมะม่วงไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0206', 'ตำซั่วมะม่วงไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0207', 'ตำซั่วมะม่วงปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0208', 'ตำซั่วมะม่วงปลาร้าปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0209', 'ตำซั่วมะม่วงปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0300', 'ตำแครอทไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0301', 'ตำแครอทปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0302', 'ตำแครอทไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0303', 'ตำแครอทปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0304', 'ตำแครอทปูปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0305', 'ตำแครอทซั่วไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0306', 'ตำแครอทซั่วไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0307', 'ตำแครอทซั่วปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0308', 'ตำแครอทซั่วปูปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0309', 'ตำแครอทซั่วปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0400', 'ตำแครอทไข่เค็มไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0401', 'ตำแครอทไข่เค็มปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0402', 'ตำแครอทไข่เค็มไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0403', 'ตำแครอทไข่เค็มปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0404', 'ตำแครอทไข่เค็มไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0405', 'ตำซั่วแครอทไข่เค็มปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0406', 'ตำซั่วแครอทไข่เค็มไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0407', 'ตำซั่วแครอทไข่เค็มปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0500', 'ตำมะเขือเทศไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0501', 'ตำมะเขือเทศปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0502', 'ตำมะเขือเทศปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0503', 'ตำซั่วมะเขือเทศไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0504', 'ตำซั่วมะเขือเทศปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0505', 'ตำซั่วมะเขือเทศ', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0506', 'ตำมะเขือเทศ', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0600', 'ตำไข่เค็มไทย', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0601', 'ตำไข่เค็มปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0602', 'ตำไข่เค็มปูปลาร้า', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0603', 'ตำซั่วไข่เค็มไทยปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0604', 'ตำซั่วไข่เค็มเทศปลาร้า', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0605', 'ตำซั่วไข่เค็มปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0700', 'ตำแตงไทย', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0701', 'ตำแตงปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0702', 'ตำแตงไทยปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0703', 'ตำแตงปลาร้า', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0704', 'ตำแตงปูปลาร้า', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0705', 'ตำซั่วแตงไทย', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0706', 'ตำซั่วแตงไทยปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0707', 'ตำซั่วแตงปลาร้า', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0708', 'ตำซั่วแตงปลาร้าปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0709', 'ตำซั่วแตงปู', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0800', 'ส้มตำทอด', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0801', 'ตำกุ้งสด', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0802', 'ตำปลาหมึก', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0803', 'ตำคอหมู', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0804', 'ตำหอยดอง', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0805', 'ตำแตง', '40', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0806', 'ตำมะม่วง', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0807', 'ตำโคราช', '35', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0900', 'ตำผลไม้', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0901', 'ตำผลไม้ไทย', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0902', 'ตำผลไม้ปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0903', 'ตำผลไม้ไทยปู', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0904', 'ตำผลไม้ปลาร้า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01000', 'ตำมาม่า', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01001', 'ตำมาม่าไข่เค็ม', '50', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01002', 'ตำมาม่าปูม้าทะเล', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01003', 'ตำมาม่าแครอทปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01004', 'ตำมาม่ากุ้งสด', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('01005', 'ตำมาม่าคอหมูย่าง', '60', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0001', 'ตำปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0002', 'ตำปูม้า 2 ตัว 220 บาท', '220', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0003', 'ตำแครอทปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0004', 'ตำแครอทปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0005', 'ตำซั่วแครอทปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0006', 'ตำแครอทปูม้าไทยปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0007', 'ตำมาม่าปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0008', 'ตำมาม่าไข่เค็มปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0009', 'ตำซั่วไข่เค็มปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0010', 'ตำปูม้ากุ้งสด', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0011', 'ตำปูม้าทะเล', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0012', 'ตำแครอทปูม้าไข่เค็ม', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0013', 'ตำซั่วปูม้ากุ้งสด', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0014', 'ตำซั่วปูม้าทะเล', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0015', 'ตำปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0016', 'ตำปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0017', 'ตำซั่วปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0018', 'ตำซั่วปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0019', 'ตำแตงปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0020', 'ตำแตงปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0021', 'ตำซั่วแตงปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0022', 'ตำซั่วแตงปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0023', 'ตำมะม่วงปูม้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0024', 'ตำมะม่วงปูม้าไทย', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0025', 'ตำมะม่วงปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('0026', 'ตำซั่วมะม่วงปูม้าปลาร้า', '110', '0', '0', '11', 'N', null, 'N');
INSERT INTO `menu` VALUES ('110', 'ปลาทับทิมเผา', '130', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('111', 'ปลาทับทิมตำไทย', '130', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('112', 'ยำแซ่บทับทิม', '130', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('120', 'ปลากระพงราดมะม่วง', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('121', 'ปลากระพงผลไม้', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('122', 'ปลากระพงทอดน้ำปลา', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('130', 'ปลาสำลีราดมะม่วง', '180', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('131', 'ปลาสำลีทอดกรอบ', '180', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('132', 'น้ำตกปลาสำลี', '180', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('133', 'จี๊ดจ๊าดปลาสำลี', '180', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('134', 'ปลาสำลีเผา', '180', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('140', 'ปลากระบอกทอดเกลือ', '110', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('141', 'ยำแซ่บกระบอก', '110', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('150', 'น้ำตกปลาช่อน', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('151', 'ปลาช่อนราดมะม่วง', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('152', 'ปลาช่อนผลไม้', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('153', 'ปลาช่อนทอดน้ำปลา', '160', '0', '0', '1', 'N', null, 'N');
INSERT INTO `menu` VALUES ('210', 'จี๊ดจ๊าดปลาทูแห้ง', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('211', 'จี๊ดจ๊าดกุ้งกรอบ', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('212', 'จี๊ดจ๊าดปลาทูน้ำ', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('213', 'ต้มยำกุ้งน้ำใส', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('214', 'ทะเลเดือด(หม้อไฟ)', '150', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('215', 'ต้มยำกุ้งแม่น้ำ(หม้อไฟ)', '150', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('216', 'โป๊ะแตก', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('217', 'แซ่บดูก', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('218', 'ต้มยำกุ้งน้ำข้น', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('219', 'ต้มแซ่บเป็ด', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('220', 'แกงลาว(แกงเปอะ)', '60', '0', '0', '2', 'N', null, 'N');
INSERT INTO `menu` VALUES ('300', 'หมึกไข่ทอด', '60', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('301', 'หอยจ้อปู', '60', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('302', 'ปากเป็ดทอด', '80', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('303', 'ทอดมันปลา', '40', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('304', 'เอ็นไก่ทอด', '50', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('305', 'ผักทอดกรอบ', '60', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('306', 'กุ้งเทปุระ', '60', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('307', 'ปอเปี๊ยะเผือก', '60', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('308', 'ข้าวเกรียบทอด', '40', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('309', 'ไส้อ่อนทอด', '80', '0', '0', '3', 'N', null, 'N');
INSERT INTO `menu` VALUES ('400', 'กุ้งเผา', '0', '0', '0', '4', 'N', null, 'N');
INSERT INTO `menu` VALUES ('401', 'หอยแครง', '60', '0', '0', '4', 'N', null, 'N');
INSERT INTO `menu` VALUES ('402', 'ปูม้าเผา', '0', '0', '0', '4', 'N', null, 'N');
INSERT INTO `menu` VALUES ('403', 'หมึกย่าง', '100', '0', '0', '4', 'N', null, 'N');
INSERT INTO `menu` VALUES ('500', 'สลัดผัก', '40', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('501', 'สลัดผักไก่กรอบ', '60', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('502', 'สลัดผักกุ้ง', '60', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('503', 'สลัดผักกุ้งกรอบ', '60', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('504', 'สลัดผลไม้', '50', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('505', 'สลัดผัก+ผลไม้ ', '70', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('506', 'สลัดปลากรอบ', '60', '0', '0', '5', 'N', null, 'N');
INSERT INTO `menu` VALUES ('600', 'ยำแหนมสด', '60', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('601', 'ยำวุ้นเส้น', '40', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('602', 'ยำส้มโอ', '60', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('603', 'ยำมาม่า', '40', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('604', 'ยำหมูยอ', '40', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('605', 'ยำทะเล', '60', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('606', 'ยำไข่เค็ม', '40', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('607', 'ยำปูม้า', '110', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('608', 'ยำเสือทอด', '90', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('609', 'ยำคอหมู', '90', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('610', 'ยำเอ็นไก่', '90', '0', '0', '6', 'N', null, 'N');
INSERT INTO `menu` VALUES ('700', 'ลาบกุ้งกรอบ', '60', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('701', 'ลาบหมู', '50', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('702', 'ลาบหมูทอด', '50', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('703', 'ลาบไก่', '50', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('704', 'ลาบเนื้อ', '50', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('705', 'ลาบวุ้นเส้น', '50', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('706', 'ลาบทะเล', '60', '0', '0', '7', 'N', null, 'N');
INSERT INTO `menu` VALUES ('800', 'ข้าวไข่เจียว', '20', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('801', 'ข้าวไข่เจียวหมูสับ', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('802', 'ข้าวผัดหมู', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('803', 'ข้าวผัดไก่', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('804', 'ข้าวผัดกุ้ง', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('805', 'ข้าวผัดปู', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('806', 'ข้าวผัดปลาหมึก', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('807', 'ข้าวผัดทะเล', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('808', 'ข้าวผัดไข่', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('809', 'ไข่เจียวหมูสับ', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('810', 'ไข่เจียวกุ้งสับ', '30', '0', '0', '8', 'N', null, 'N');
INSERT INTO `menu` VALUES ('900', 'ตับหวาน', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('901', 'น้ำตกหมู', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('902', 'น้ำตกเนื้อ', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('903', 'กุ้งแช่น้ำปลา', '60', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('904', 'เสือร้องไห้', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('905', 'หมูร้องไห้', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('906', 'ซุปหน่อไม้', '20', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('907', 'ปูอัด', '60', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('908', 'หมูลืมกลืน', '60', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('909', 'หมูแดดเดียว', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('910', 'ใส้กรอกอีสาน', '80', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('911', 'มาม่าผัดฉ่า', '40', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('912', 'พล่ากุ้ง', '60', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('913', 'ปูนิ่มกะเทียม', '120', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('914', 'ซุปมะเขือ', '50', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('915', 'มอสาม(เม็ดมะม่วงหิมพานอบเกลือ)', '60', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('916', 'กุ้งอบเกลือ', '80', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('917', 'หมูมะนาว', '80', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('918', 'พล่าปูม้าเผา', '120', '0', '0', '9', 'N', null, 'N');
INSERT INTO `menu` VALUES ('40', 'โค๊ก', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('41', 'แป็บซี่', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('42', 'น้ำส้ม', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('43', 'น้ำเขียว', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('44', 'น้ำสไปร์', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('45', 'น้ำ 7 อัพ', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('50', 'spy', '45', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('51', 'LEO', '65', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('52', 'Sing', '75', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('53', 'Hei', '85', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('54', 'Hei สด', '160', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('55', 'Chang สด', '330', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('60', 'รีเจนซี่แบน', '260', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('61', 'รีเจนซี่กลม', '480', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('62', 'LM', '75', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('63', 'กรองทิพย์', '65', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('64', 'ไฟแช๊ค', '15', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('70', 'น้ำกีวี่ปั่น', '30', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('71', 'น้ำสตอร์เบอร์ปั่น', '30', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('72', 'น้ำบลูเบอร์รี่ปั่น', '30', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('73', 'น้ำโยเกิร์ตปั่น', '30', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('74', 'น้ำส้มปั่น', '30', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('75', 'น้ำส้มคั้น', '20', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('76', 'ไอติม', '10', '0', '0', '10', 'N', null, 'N');
INSERT INTO `menu` VALUES ('77', 'น้ำแข็ง', '10', '0', '0', '13', 'N', null, 'Y');
INSERT INTO `menu` VALUES ('78', 'น้ำ', '10', '0', '0', '13', 'N', null, 'Y');
INSERT INTO `menu` VALUES ('79', 'ข้าวเหนียว', '10', '0', '0', '13', 'N', '', 'Y');
INSERT INTO `menu` VALUES ('80', 'ข้าวเหนียวทอด', '20', '0', '0', '13', 'N', null, 'Y');
INSERT INTO `menu` VALUES ('81', 'ขนมจีน', '10', '0', '0', '13', 'N', null, 'Y');
INSERT INTO `menu` VALUES ('82', 'ข้าวสวย', '10', '0', '0', '13', 'N', null, 'Y');
INSERT INTO `menugroup` VALUES ('1', 'ปลา');
INSERT INTO `menugroup` VALUES ('2', 'อาหารน้ำ');
INSERT INTO `menugroup` VALUES ('3', 'ทอด');
INSERT INTO `menugroup` VALUES ('4', 'เผา');
INSERT INTO `menugroup` VALUES ('5', 'สลัด');
INSERT INTO `menugroup` VALUES ('6', 'ยำ');
INSERT INTO `menugroup` VALUES ('7', 'ลาบ');
INSERT INTO `menugroup` VALUES ('8', 'ข้าว');
INSERT INTO `menugroup` VALUES ('9', 'อื่นๆ');
INSERT INTO `menugroup` VALUES ('10', 'เครื่องดื่ม');
INSERT INTO `menugroup` VALUES ('11', 'ส้มตำ');
INSERT INTO `menugroup` VALUES ('12', 'รวม');
INSERT INTO `menugroup` VALUES ('13', 'ประจำ');
INSERT INTO `order_status` VALUES ('1', 'อยู๋ระหว่างให้บริการ');
INSERT INTO `order_status` VALUES ('2', 'ชำระเงินแล้ว');
INSERT INTO `order_status` VALUES ('3', 'จอง');
INSERT INTO `pname` VALUES ('คุณ');
INSERT INTO `pname` VALUES ('คุณหญิง');
INSERT INTO `pname` VALUES ('จ.ต.');
INSERT INTO `pname` VALUES ('จ.ต.หญิง');
INSERT INTO `pname` VALUES ('จ.ท.');
INSERT INTO `pname` VALUES ('จ.ท.หญิง');
INSERT INTO `pname` VALUES ('จ.ส.ต.');
INSERT INTO `pname` VALUES ('จ.ส.ต.หญิง');
INSERT INTO `pname` VALUES ('จ.ส.ท.');
INSERT INTO `pname` VALUES ('จ.ส.ท.หญิง');
INSERT INTO `pname` VALUES ('จ.ส.อ.');
INSERT INTO `pname` VALUES ('จ.ส.อ.หญิง');
INSERT INTO `pname` VALUES ('จ.อ.');
INSERT INTO `pname` VALUES ('จ.อ.หญิง');
INSERT INTO `pname` VALUES ('จ่าอากาศตรีหญิง');
INSERT INTO `pname` VALUES ('จ่าอากาศตรี');
INSERT INTO `pname` VALUES ('จ่าอากาศโทหญิง');
INSERT INTO `pname` VALUES ('จ่าอากาศโท');
INSERT INTO `pname` VALUES ('จ่าอากาศเอกหญิง');
INSERT INTO `pname` VALUES ('จ่าอากาศเอก');
INSERT INTO `pname` VALUES ('เจ้าอธิการ');
INSERT INTO `pname` VALUES ('ด.ช.');
INSERT INTO `pname` VALUES ('ด.ญ.');
INSERT INTO `pname` VALUES ('ด.ต.');
INSERT INTO `pname` VALUES ('ด.ต.หญิง');
INSERT INTO `pname` VALUES ('ดร.');
INSERT INTO `pname` VALUES ('ท.พ.');
INSERT INTO `pname` VALUES ('น.ช.');
INSERT INTO `pname` VALUES ('น.ต.');
INSERT INTO `pname` VALUES ('น.ต.พ.ญ.');
INSERT INTO `pname` VALUES ('น.ต.ม.ล.');
INSERT INTO `pname` VALUES ('น.ต.ม.ล.หญิง');
INSERT INTO `pname` VALUES ('น.ต.หญิง');
INSERT INTO `pname` VALUES ('น.พ.');
INSERT INTO `pname` VALUES ('น.ส.');
INSERT INTO `pname` VALUES ('น.อ.พิเศษ');
INSERT INTO `pname` VALUES ('น.อ.พิเศษหญิง');
INSERT INTO `pname` VALUES ('นนส.');
INSERT INTO `pname` VALUES ('นนส.หญิง');
INSERT INTO `pname` VALUES ('นรจ.');
INSERT INTO `pname` VALUES ('นรจ.หญิง');
INSERT INTO `pname` VALUES ('นรต.');
INSERT INTO `pname` VALUES ('นรต.หญิง');
INSERT INTO `pname` VALUES ('นักเรียนจ่าอากาศหญิง');
INSERT INTO `pname` VALUES ('นักเรียนจ่าอากาศ');
INSERT INTO `pname` VALUES ('นักเรียนนายเรืออากาศ');
INSERT INTO `pname` VALUES ('นักเรียนนายเรืออากาศหญิง');
INSERT INTO `pname` VALUES ('นาง');
INSERT INTO `pname` VALUES ('นาย');
INSERT INTO `pname` VALUES ('นาวาโท');
INSERT INTO `pname` VALUES ('นาวาโทหญิง');
INSERT INTO `pname` VALUES ('นาวาอากาศตรี');
INSERT INTO `pname` VALUES ('นาวาอากาศตรีหญิง');
INSERT INTO `pname` VALUES ('นาวาอากาศโท');
INSERT INTO `pname` VALUES ('นาวาอากาศโทหญิง');
INSERT INTO `pname` VALUES ('นาวาอากาศเอก');
INSERT INTO `pname` VALUES ('นาวาอากาศเอกหญิง');
INSERT INTO `pname` VALUES ('นาวาเอก');
INSERT INTO `pname` VALUES ('นาวาเอกหญิง');
INSERT INTO `pname` VALUES ('บาทหลวง');
INSERT INTO `pname` VALUES ('พ.จ.ต.');
INSERT INTO `pname` VALUES ('พ.จ.ต.หญิง');
INSERT INTO `pname` VALUES ('พ.จ.ท.');
INSERT INTO `pname` VALUES ('พ.จ.ท.หญิง');
INSERT INTO `pname` VALUES ('พ.จ.อ.');
INSERT INTO `pname` VALUES ('พ.จ.อ.หญิง');
INSERT INTO `pname` VALUES ('พ.ญ.');
INSERT INTO `pname` VALUES ('พ.ต.');
INSERT INTO `pname` VALUES ('พ.ต.ต.');
INSERT INTO `pname` VALUES ('พ.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('พ.ต.ท.');
INSERT INTO `pname` VALUES ('พ.ต.ท.หญิง');
INSERT INTO `pname` VALUES ('พ.ต.หญิง');
INSERT INTO `pname` VALUES ('พ.ต.อ.');
INSERT INTO `pname` VALUES ('พ.ต.อ.หญิง');
INSERT INTO `pname` VALUES ('พ.ท.');
INSERT INTO `pname` VALUES ('พ.ท.น.พ.');
INSERT INTO `pname` VALUES ('พ.ท.น.พ.หญิง');
INSERT INTO `pname` VALUES ('พ.ท.หญิง');
INSERT INTO `pname` VALUES ('พ.อ.');
INSERT INTO `pname` VALUES ('พ.อ.ท.');
INSERT INTO `pname` VALUES ('พ.อ.พิเศษ');
INSERT INTO `pname` VALUES ('พ.อ.พิเศษหญิง');
INSERT INTO `pname` VALUES ('พ.อ.หญิง');
INSERT INTO `pname` VALUES ('พ.อ.อ.');
INSERT INTO `pname` VALUES ('พระ');
INSERT INTO `pname` VALUES ('พระครู');
INSERT INTO `pname` VALUES ('พระครูใบฎีกา');
INSERT INTO `pname` VALUES ('พระครูปลัด');
INSERT INTO `pname` VALUES ('พระปริยัติ');
INSERT INTO `pname` VALUES ('พระมหา');
INSERT INTO `pname` VALUES ('พระสมุห์');
INSERT INTO `pname` VALUES ('พระอธิการ');
INSERT INTO `pname` VALUES ('พล.ต');
INSERT INTO `pname` VALUES ('พล.ต.ต.');
INSERT INTO `pname` VALUES ('พล.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('พล.ตหญิง');
INSERT INTO `pname` VALUES ('พล.ท.');
INSERT INTO `pname` VALUES ('พล.ท.หญิง');
INSERT INTO `pname` VALUES ('พล.ร.ต.');
INSERT INTO `pname` VALUES ('พล.ร.ต.หญิง');
INSERT INTO `pname` VALUES ('พล.อ.');
INSERT INTO `pname` VALUES ('พล.อ.ต.');
INSERT INTO `pname` VALUES ('พล.อ.ต.หญิง');
INSERT INTO `pname` VALUES ('พล.อ.ท.');
INSERT INTO `pname` VALUES ('พล.อ.ท.หญิง');
INSERT INTO `pname` VALUES ('พล.อ.หญิง');
INSERT INTO `pname` VALUES ('พล.อ.อ.');
INSERT INTO `pname` VALUES ('พล.อ.อ.หญิง');
INSERT INTO `pname` VALUES ('พลตำรวจ');
INSERT INTO `pname` VALUES ('พลตำรวจสมัคร');
INSERT INTO `pname` VALUES ('พลตำรวจสมัครหญิง');
INSERT INTO `pname` VALUES ('พลตำรวจสำรอง');
INSERT INTO `pname` VALUES ('พลตำรวจสำรองพิเศษ');
INSERT INTO `pname` VALUES ('พลตำรวจสำรองพิเศษหญิง');
INSERT INTO `pname` VALUES ('พลตำรวจสำรองหญิง');
INSERT INTO `pname` VALUES ('พลตำรวจหญิง');
INSERT INTO `pname` VALUES ('พลทหารหญิง');
INSERT INTO `pname` VALUES ('พลฯ');
INSERT INTO `pname` VALUES ('พลฯ อาสา');
INSERT INTO `pname` VALUES ('พลฯทหารเรือ');
INSERT INTO `pname` VALUES ('พลฯทหารเรือหญิง');
INSERT INTO `pname` VALUES ('พลฯทหารอากาศ');
INSERT INTO `pname` VALUES ('พลฯทหารอากาศหญิง');
INSERT INTO `pname` VALUES ('พันจ่าอากาศตรีหญิง');
INSERT INTO `pname` VALUES ('พันจ่าอากาศตรี');
INSERT INTO `pname` VALUES ('พันจ่าอากาศโทหญิง');
INSERT INTO `pname` VALUES ('พันจ่าอากาศเอกหญิง');
INSERT INTO `pname` VALUES ('ม.จ.');
INSERT INTO `pname` VALUES ('ม.ร.ว.');
INSERT INTO `pname` VALUES ('ม.ล.');
INSERT INTO `pname` VALUES ('แม่ชี');
INSERT INTO `pname` VALUES ('ร.ต.');
INSERT INTO `pname` VALUES ('ร.ต.ต.');
INSERT INTO `pname` VALUES ('ร.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('ร.ต.ท.');
INSERT INTO `pname` VALUES ('ร.ต.ท.หญิง');
INSERT INTO `pname` VALUES ('ร.ต.ม.ล.');
INSERT INTO `pname` VALUES ('ร.ต.ม.ล.หญิง');
INSERT INTO `pname` VALUES ('ร.ต.หญิง');
INSERT INTO `pname` VALUES ('ร.ต.อ.');
INSERT INTO `pname` VALUES ('ร.ต.อ.หญิง');
INSERT INTO `pname` VALUES ('ร.ท.');
INSERT INTO `pname` VALUES ('ร.ท.หญิง');
INSERT INTO `pname` VALUES ('ร.อ.');
INSERT INTO `pname` VALUES ('ร.อ.หญิง');
INSERT INTO `pname` VALUES ('เรืออากาศตรี');
INSERT INTO `pname` VALUES ('เรืออากาศตรีหญิง');
INSERT INTO `pname` VALUES ('เรืออากาศโท');
INSERT INTO `pname` VALUES ('เรืออากาศโทหญิง');
INSERT INTO `pname` VALUES ('เรืออากาศเอก');
INSERT INTO `pname` VALUES ('เรืออากาศเอกหญิง');
INSERT INTO `pname` VALUES ('ว่าที่ น.ต.');
INSERT INTO `pname` VALUES ('ว่าที่ น.ต.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ น.อ.');
INSERT INTO `pname` VALUES ('ว่าที่ น.อ.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.ต.');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.ท.');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.ท.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ต.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ท.');
INSERT INTO `pname` VALUES ('ว่าที่ พ.ท.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ พ.อ.');
INSERT INTO `pname` VALUES ('ว่าที่ พ.อ.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.ต.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.ท.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.ท.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.อ.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ต.อ.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ท.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.ท.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่ ร.อ.');
INSERT INTO `pname` VALUES ('ว่าที่ ร.อ.หญิง');
INSERT INTO `pname` VALUES ('ว่าที่นาวาอากาศตรีหญิง');
INSERT INTO `pname` VALUES ('ว่าที่นาวาอากาศตรี');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศตรีหญิง');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศตรี');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศโท');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศโทหญิง');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศเอก');
INSERT INTO `pname` VALUES ('ว่าที่เรืออากาศเอกหญิง');
INSERT INTO `pname` VALUES ('ศจ.น.พ.');
INSERT INTO `pname` VALUES ('ส.ณ.');
INSERT INTO `pname` VALUES ('ส.ต.');
INSERT INTO `pname` VALUES ('ส.ต.ต.');
INSERT INTO `pname` VALUES ('ส.ต.ต.หญิง');
INSERT INTO `pname` VALUES ('ส.ต.ท.');
INSERT INTO `pname` VALUES ('ส.ต.ท.หญิง');
INSERT INTO `pname` VALUES ('ส.ต.หญิง');
INSERT INTO `pname` VALUES ('ส.ต.อ.');
INSERT INTO `pname` VALUES ('ส.ต.อ.หญิง');
INSERT INTO `pname` VALUES ('ส.ท.');
INSERT INTO `pname` VALUES ('ส.ท.หญิง');
INSERT INTO `pname` VALUES ('ส.อ.');
INSERT INTO `pname` VALUES ('ส.อ.หญิง');
INSERT INTO `pname` VALUES ('หม่อม');
INSERT INTO `pname` VALUES ('อส.');
INSERT INTO `pname` VALUES ('อส.ทพ.');
INSERT INTO `sex` VALUES ('1', 'ชาย');
INSERT INTO `sex` VALUES ('2', 'หญิง');
INSERT INTO `table_info` VALUES ('A', '01', '1', 'ลูกค้าทั่วไป', '1', '0', '2');
INSERT INTO `table_info` VALUES ('A', '02', null, 'ลูกค้าทั่วไป', '0', '0', '1');
INSERT INTO `table_info` VALUES ('A', '03', null, 'ลูกค้าทั่วไป', '0', '0', '1');
INSERT INTO `table_settings` VALUES ('A', '1', 'โต๊ะที่ 01', '3');
INSERT INTO `table_settings` VALUES ('A', '2', 'โต๊ะที่ 2', '3');
INSERT INTO `table_settings` VALUES ('A', '3', 'โต๊ะที่ 3', '1');
INSERT INTO `table_settings` VALUES ('A', '4', 'โต๊ะที่ 4', '1');
INSERT INTO `table_settings` VALUES ('A', '5', 'โต๊ะที่ 5', '1');
INSERT INTO `table_settings` VALUES ('A', '6', 'โต๊ะที่ 6', '1');
INSERT INTO `table_settings` VALUES ('A', '7', 'โต๊ะที่ 7', '1');
INSERT INTO `table_settings` VALUES ('A', '11', 'โต๊ะที่ 11', '1');
INSERT INTO `table_settings` VALUES ('A', '10', 'โต๊ะที่ 10', '1');
INSERT INTO `table_settings` VALUES ('A', '9', 'โต๊ะที่ 9', '1');
INSERT INTO `table_settings` VALUES ('A', '8', 'โต๊ะที่ 8', '1');
INSERT INTO `table_settings` VALUES ('B', '1', 'โต๊ะที่ 1', '1');
INSERT INTO `table_settings` VALUES ('B', '2', 'โต๊ะที่ 2', '1');
INSERT INTO `table_settings` VALUES ('B', '3', 'โต๊ะที่ 3', '1');
INSERT INTO `table_settings` VALUES ('B', '4', 'โต๊ะที่ 4', '1');
INSERT INTO `table_settings` VALUES ('B', '5', 'โต๊ะที่ 5', '1');
INSERT INTO `table_settings` VALUES ('B', '6', 'โต๊ะที่ 6', '1');
INSERT INTO `table_settings` VALUES ('B', '7', 'โต๊ะที่ 7', '1');
INSERT INTO `table_settings` VALUES ('B', '8', 'โต๊ะที่ 8', '1');
INSERT INTO `table_settings` VALUES ('B', '9', 'โต๊ะที่ 9', '1');
INSERT INTO `table_settings` VALUES ('B', '10', 'โต๊ะที่ 10', '1');
INSERT INTO `table_settings` VALUES ('B', '11', 'โต๊ะที่ 11', '1');
INSERT INTO `table_settings` VALUES ('B', '12', 'โต๊ะที่ 12', '3');
INSERT INTO `table_settings` VALUES ('B', '13', 'โต๊ะที่ 13', '1');
INSERT INTO `table_settings` VALUES ('B', '14', 'โต๊ะที่ 14', '1');
INSERT INTO `table_settings` VALUES ('B', '15', 'โต๊ะที่ 15', '1');
INSERT INTO `table_settings` VALUES ('B', '16', 'โต๊ะที่ 16', '1');
INSERT INTO `table_settings` VALUES ('C', '1', 'โต๊ะที่ 1', '3');
INSERT INTO `table_settings` VALUES ('C', '2', 'โต๊ะที่ 2', '1');
INSERT INTO `table_settings` VALUES ('C', '3', 'โต๊ะที่ 3', '1');
INSERT INTO `table_settings` VALUES ('C', '4', 'โต๊ะที่ 4', '1');
INSERT INTO `table_settings` VALUES ('C', '5', 'โต๊ะที่ 5', '1');
INSERT INTO `table_settings` VALUES ('C', '6', 'โต๊ะที่ 6', '1');
INSERT INTO `table_settings` VALUES ('C', '7', 'โต๊ะที่ 7', '1');
INSERT INTO `table_settings` VALUES ('C', '8', 'โต๊ะที่ 8', '1');
INSERT INTO `table_settings` VALUES ('D', '1', 'โต๊ะที่ 1', '1');
INSERT INTO `table_settings` VALUES ('D', '2', 'โต๊ะที่ 2', '1');
INSERT INTO `table_settings` VALUES ('D', '3', 'โต๊ะที่ 3', '1');
INSERT INTO `table_settings` VALUES ('D', '4', 'โต๊ะที่ 4', '1');
INSERT INTO `table_settings` VALUES ('D', '5', 'โต๊ะที่ 5', '1');
INSERT INTO `table_settings` VALUES ('D', '6', 'โต๊ะที่ 6', '1');
INSERT INTO `table_settings` VALUES ('D', '7', 'โต๊ะที่ 7', '1');
INSERT INTO `table_settings` VALUES ('D', '8', 'โต๊ะที่ 8', '1');
INSERT INTO `table_settings` VALUES ('D', '9', 'โต๊ะที่ 9', '1');
INSERT INTO `table_settings` VALUES ('D', '10', 'โต๊ะที่ 10', '1');
INSERT INTO `table_settings` VALUES ('D', '11', 'โต๊ะที่ 11', '1');
INSERT INTO `table_settings` VALUES ('D', '12', 'โต๊ะที่ 12', '1');
INSERT INTO `table_settings` VALUES ('D', '13', 'โต๊ะที่ 13', '1');
INSERT INTO `table_status` VALUES ('1', 'ว่าง', 'CornflowerBlue');
INSERT INTO `table_status` VALUES ('2', 'จอง', 'Khaki');
INSERT INTO `table_status` VALUES ('3', 'ไม่ว่าง', 'Yellow');
INSERT INTO `table_status` VALUES ('4', 'รอคิดเงิน', 'DarkOrange');
INSERT INTO `table_status` VALUES ('5', 'รออาหาร', 'Red');
INSERT INTO `table_status` VALUES ('6', 'ระงับการให้บริการ', 'Gainsboro');
INSERT INTO `zone_settings` VALUES ('A', 'Zone A', '1', '11');
INSERT INTO `zone_settings` VALUES ('B', 'Zone B', '1', '16');
INSERT INTO `zone_settings` VALUES ('C', 'Zone C', '1', '8');
INSERT INTO `zone_settings` VALUES ('D', 'Zone D', '1', '13');
INSERT INTO `zone_settings` VALUES ('E', 'Zone E', '2', '0');
INSERT INTO `zone_settings` VALUES ('F', 'Zone F', '2', '0');
INSERT INTO `zone_settings` VALUES ('G', 'Zone G', '2', '0');
INSERT INTO `zone_settings` VALUES ('H', 'Zone H', '2', '0');
INSERT INTO `zone_settings` VALUES ('I', 'Zone I', '2', '0');
INSERT INTO `zone_settings` VALUES ('J', 'Zone J', '2', '0');
INSERT INTO `zone_settings` VALUES ('K', 'Zone K', '2', '0');
INSERT INTO `zone_settings` VALUES ('L', 'Zone L', '2', '0');
INSERT INTO `zone_settings` VALUES ('M', 'Zone M', '2', '0');
INSERT INTO `zone_settings` VALUES ('N', 'Zone N', '2', '0');
INSERT INTO `zone_settings` VALUES ('O', 'Zone O', '2', '0');
INSERT INTO `zone_settings` VALUES ('P', 'Zone P', '2', '0');
INSERT INTO `zone_settings` VALUES ('Q', 'Zone Q', '2', '0');
INSERT INTO `zone_settings` VALUES ('R', 'Zone R', '2', '0');
INSERT INTO `zone_settings` VALUES ('S', 'Zone S', '1', '0');
INSERT INTO `zone_settings` VALUES ('T', 'Zone T', '2', '0');
INSERT INTO `zone_settings` VALUES ('U', 'Zone U', '2', '0');
INSERT INTO `zone_settings` VALUES ('V', 'Zone V', '2', '0');
INSERT INTO `zone_settings` VALUES ('W', 'Zone W', '2', '0');
INSERT INTO `zone_settings` VALUES ('X', 'Zone X', '2', '0');
INSERT INTO `zone_settings` VALUES ('Y', 'Zone Y', '2', '0');
INSERT INTO `zone_settings` VALUES ('Z', 'Zone Z', '2', '0');
INSERT INTO `zone_status` VALUES ('1', 'เปิดบริการ', 'Chartreuse');
INSERT INTO `zone_status` VALUES ('2', 'ปิดบริการ', 'Gainsboro');
INSERT INTO `zone_status` VALUES ('3', 'เต็ม', 'IndianRed');

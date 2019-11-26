-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 26, 2019 at 02:13 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `super_awesome_child_farm`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(10) UNSIGNED NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 1,
  `is_dier` tinyint(1) NOT NULL DEFAULT 1,
  `name` varchar(100) NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `active`, `is_dier`, `name`, `created_at`, `updated_at`) VALUES
(1, 1, 1, 'Eenden', NULL, NULL),
(2, 1, 1, 'Ezels', NULL, NULL),
(3, 1, 1, 'Geiten', NULL, NULL),
(4, 1, 1, 'Kippen', NULL, NULL),
(5, 1, 1, 'Varkens', NULL, NULL),
(6, 1, 0, 'Hooi en Voer', NULL, NULL),
(7, 1, 0, 'Stagiaires', NULL, NULL),
(8, 1, 0, 'Vrijwilligers', NULL, NULL),
(9, 1, 0, 'Tuin en Terrein', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `colors`
--

CREATE TABLE `colors` (
  `id` int(10) UNSIGNED NOT NULL,
  `color` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `colors`
--

INSERT INTO `colors` (`id`, `color`) VALUES
(1, 'DarkBlue'),
(2, 'DarkRed'),
(3, 'DarkGreen'),
(4, 'DarkViolet'),
(5, 'DarkOrange'),
(6, 'DarkCyan'),
(7, 'DeepPink'),
(8, 'DarkSlateGrey'),
(9, 'Chocolate'),
(10, 'LimeGreen');

-- --------------------------------------------------------

--
-- Table structure for table `comment`
--

CREATE TABLE `comment` (
  `id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `message_id` int(10) UNSIGNED NOT NULL,
  `comment` text NOT NULL,
  `marked` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `comment`
--

INSERT INTO `comment` (`id`, `user_id`, `message_id`, `comment`, `marked`, `created_at`, `updated_at`) VALUES
(1, 2, 1, 'test comment', 0, '2018-08-02 09:35:02', '2018-08-02 09:35:02'),
(2, 1, 2, 'Het comment wordt nu gewijzigd in een testcomment', 0, '2018-08-02 09:35:02', '2018-08-02 09:35:02'),
(3, 1, 3, 'Ja, vind ik ook. Hij moet gewoon niet met dieren werken.', 0, '2018-08-06 12:00:38', '2018-08-06 12:00:38'),
(4, 1, 1, 'Wat zielig voor haar!', 0, '2018-08-06 12:09:32', '2018-08-06 12:09:32'),
(5, 1, 5, 'Wat schattig!', 0, '2018-08-06 12:09:44', '2018-08-06 12:09:44'),
(7, 2, 1, 'Het gaat nu al wat beter. Een ezel stoot zich immers niet twee keer aan dezelfde steen.', 0, '2018-08-06 12:10:47', '2018-08-06 12:10:47'),
(8, 2, 4, 'Heb ik zojuist gedaan.', 0, '2018-08-06 12:11:03', '2018-08-06 12:11:03'),
(9, 2, 9, 'Ik zal morgen wat boontjes meenemen.', 0, '2018-08-06 12:11:23', '2018-08-06 12:11:23'),
(10, 3, 2, 'Ik heb er eentje kunnen vangen.', 1, '2018-08-06 12:11:50', '2018-08-06 12:11:50'),
(11, 3, 3, 'Vandaag heeft hij het kippenvoer laten vallen.', 0, '2018-08-06 12:12:13', '2018-08-06 12:12:13'),
(12, 3, 10, 'Ik zal er op letten!', 0, '2018-08-06 12:12:27', '2019-09-12 13:25:03'),
(13, 5, 1, 'hoi mooi', 0, '2019-09-12 13:29:40', '2019-10-14 09:52:38'),
(14, 1, 3, 'vggh', 0, '2019-09-12 13:31:25', '2019-09-12 13:31:25'),
(15, 1, 3, 'vggh', 0, '2019-09-12 14:21:21', '2019-09-12 14:21:21'),
(16, 1, 11, 'test comment', 1, '2019-09-20 09:08:07', '2019-09-20 09:08:07'),
(17, 6, 12, 'Nog een test man!', 0, '2019-10-04 14:31:24', '2019-10-04 14:31:24'),
(18, 6, 13, 'Echt dik!', 0, '2019-10-07 13:23:17', '2019-10-07 13:23:17'),
(19, 6, 15, 'mm\r\n', 0, '2019-10-07 13:25:53', '2019-10-07 13:25:53'),
(20, 6, 17, 'Een hoop vrijwilligers zijn op vakantie trouwens. ', 0, '2019-10-09 12:30:28', '2019-10-10 09:08:25'),
(21, 6, 17, 'Ik voel me zo alleen hier... ugh...', 0, '2019-10-09 12:32:10', '2019-10-10 09:19:13'),
(22, 2, 17, 'Ik ben er ook!', 0, '2019-10-11 11:56:07', '2019-10-11 11:56:07'),
(23, 6, 17, 'Oh neeee!', 0, '2019-10-14 08:03:28', '2019-10-14 08:04:12'),
(24, 6, 19, 'Cool', 0, '2019-10-14 13:43:49', '2019-10-14 13:43:49'),
(25, 6, 3, 'ugh', 0, '2019-10-14 13:47:39', '2019-10-14 13:47:39'),
(26, 6, 3, 'kk', 0, '2019-10-15 08:36:20', '2019-10-15 08:36:20'),
(27, 6, 10, 'Zal ik doen!', 0, '2019-10-15 08:39:52', '2019-10-15 08:39:52'),
(28, 4, 3, 'ugh', 0, '2019-10-15 08:46:37', '2019-10-15 08:46:37');

-- --------------------------------------------------------

--
-- Table structure for table `field_data`
--

CREATE TABLE `field_data` (
  `id` int(10) UNSIGNED NOT NULL,
  `field_id` int(10) UNSIGNED NOT NULL,
  `subject_id` int(10) UNSIGNED NOT NULL,
  `text` varchar(100) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `field_data`
--

INSERT INTO `field_data` (`id`, `field_id`, `subject_id`, `text`, `date`, `created_at`, `updated_at`) VALUES
(1, 1, 23, 'Daffy', NULL, NULL, NULL),
(2, 2, 23, NULL, '2017-06-25', NULL, NULL),
(3, 3, 23, 'paracetamol 20mg', '2018-02-04', NULL, NULL),
(4, 3, 23, 'prik', '2018-05-09', NULL, NULL),
(5, 1, 1, 'Bibi', NULL, NULL, NULL),
(6, 1, 24, 'Donald', NULL, NULL, NULL),
(7, 1, 7, 'Dotje', NULL, NULL, NULL),
(8, 1, 2, 'Fleur', NULL, NULL, NULL),
(9, 1, 3, 'Mara', NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `field_per_category`
--

CREATE TABLE `field_per_category` (
  `id` int(10) UNSIGNED NOT NULL,
  `field_id` int(10) UNSIGNED NOT NULL,
  `category_id` int(10) UNSIGNED NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `field_per_category`
--

INSERT INTO `field_per_category` (`id`, `field_id`, `category_id`, `created_at`, `updated_at`) VALUES
(1, 1, 3, NULL, NULL),
(2, 2, 3, NULL, NULL),
(3, 3, 3, NULL, NULL),
(4, 1, 1, NULL, NULL),
(5, 2, 1, NULL, NULL),
(6, 3, 1, NULL, NULL),
(7, 1, 2, NULL, NULL),
(8, 2, 2, NULL, NULL),
(9, 3, 2, NULL, NULL),
(10, 1, 4, NULL, NULL),
(11, 2, 4, NULL, NULL),
(12, 3, 4, NULL, NULL),
(13, 1, 5, NULL, NULL),
(14, 2, 5, NULL, NULL),
(15, 3, 5, NULL, NULL),
(16, 4, 1, NULL, NULL),
(17, 5, 3, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `field_table`
--

CREATE TABLE `field_table` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL,
  `type` varchar(100) NOT NULL,
  `title` varchar(100) DEFAULT NULL,
  `is_subject` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `field_table`
--

INSERT INTO `field_table` (`id`, `name`, `type`, `title`, `is_subject`) VALUES
(1, 'Naam', 'text', NULL, 0),
(2, 'Geboorte Datum', 'date', NULL, 0),
(3, 'Entingen', 'table', 'medicijnen', 0),
(4, 'Vader', 'text', NULL, 0),
(5, 'Hoefverzorging', 'table', 'Werkzaamheden', 0);

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE `message` (
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `visible_for_role_id` int(10) UNSIGNED NOT NULL,
  `category_id` int(10) UNSIGNED NOT NULL,
  `subject_id` int(10) UNSIGNED DEFAULT NULL,
  `message` text NOT NULL,
  `followup` tinyint(1) NOT NULL DEFAULT 0,
  `marked` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `followup_user_id` int(10) UNSIGNED NOT NULL,
  `followup_date` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `message`
--

INSERT INTO `message` (`updated_at`, `id`, `user_id`, `visible_for_role_id`, `category_id`, `subject_id`, `message`, `followup`, `marked`, `created_at`, `followup_user_id`, `followup_date`) VALUES
('2018-08-01 06:51:54', 1, 2, 2, 3, 5, 'Luna de geit heeft haar hoofd gestoten.', 0, 0, '2018-08-01 06:51:54', 0, NULL),
('2019-09-12 13:30:46', 2, 1, 3, 4, NULL, 'De kippen zijn vannacht ontsnapt. Eentje loopt nog vrij rond en moet nog gevangen worden.', 1, 1, '2018-08-01 06:53:18', 0, NULL),
('2019-10-14 10:03:04', 3, 3, 2, 7, 10, 'Luuk bakt er echt niks van. Helemaal niet.', 1, 0, '2018-08-06 09:55:25', 0, NULL),
('2018-08-06 09:55:53', 4, 3, 2, 6, 8, 'Er moet nieuw hooi besteld worden. Het is bijna op.', 0, 1, '2018-08-06 09:55:53', 0, NULL),
('2018-08-06 09:56:57', 5, 3, 1, 5, NULL, 'De varkens hebben jonkies gekregen. Aww, wat een schatjes!', 0, 0, '2018-08-06 09:56:57', 0, NULL),
('2018-08-06 10:02:06', 7, 2, 2, 1, NULL, 'Toen ik vanmorgen aankwam liepen de eenden los rond. Willen jullie a.u.b. kijken dat het hek goed dicht zit voordat jullie \'s avonds weggaan?', 0, 1, '2018-08-06 10:02:06', 0, NULL),
('2018-08-06 10:05:42', 8, 1, 3, 3, NULL, 'Er is een hittegolf gaande. We moeten water sproeien op het gras bij de geiten.', 1, 1, '2018-08-06 10:05:42', 0, NULL),
('2018-08-06 10:07:50', 9, 1, 2, 4, NULL, 'De kippen vinden het erg lekker om boontjes te eten. Geeft ze maar wat extras.', 0, 0, '2018-08-06 10:07:50', 0, NULL),
('2018-08-06 10:11:50', 10, 1, 2, 2, 2, 'Fleur is een beetje eenzaam. Geef haar wat meer aandacht.', 0, 1, '2018-08-06 10:11:50', 0, NULL),
('2019-09-20 09:07:29', 11, 1, 2, 3, 3, 'Mara is ziek', 0, 0, '2019-09-20 09:07:29', 0, NULL),
('2019-10-01 11:22:45', 12, 1, 5, 1, NULL, 'Er zijn weer nieuwe eenden bijgekomen', 0, 0, '2019-10-01 11:22:45', 0, NULL),
('2019-10-07 13:11:53', 13, 6, 5, 1, 24, 'Wat een dikkert!', 0, 0, '2019-10-07 13:11:53', 0, NULL),
('2019-10-07 13:12:43', 14, 6, 5, 1, NULL, 'Ik hou van eenden, man!', 0, 0, '2019-10-07 13:12:43', 0, NULL),
('2019-10-07 13:24:04', 15, 6, 5, 2, 2, 'Wow', 0, 0, '2019-10-07 13:24:04', 0, NULL),
('2019-10-07 13:37:18', 16, 6, 5, 9, 12, 'De brandnetels overheersen bij de speeltuin, wie gaat je weghalen?', 0, 1, '2019-10-07 13:37:18', 0, NULL),
('2019-10-14 09:49:39', 17, 6, 4, 1, 24, 'Kan iemand Donald te eten geven? Karin is op vakantie...', 1, 0, '2019-10-09 12:18:31', 6, '2019-10-15 12:14:57'),
('2019-10-18 09:09:51', 18, 6, 1, 8, NULL, 'Goed gedaan allemaal!', 1, 0, '2019-10-14 08:04:59', 0, NULL),
('2019-10-14 09:57:01', 19, 3, 5, 1, NULL, 'hoi', 0, 0, '2019-10-14 09:57:01', 0, NULL),
('2019-10-16 08:08:47', 21, 6, 1, 4, NULL, 'Zouden we niet wat kippen erbij kunnen halen?', 0, 0, '2019-10-15 10:01:07', 0, NULL),
('2019-10-18 09:24:43', 22, 6, 2, 3, 4, 'Diderik, kan je Margriet even geruststellen? Ze is nogal geschrokken door de bliksem.', 1, 1, '2019-10-18 09:23:48', 4, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `password_resets`
--

CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(10) UNSIGNED NOT NULL,
  `role` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `role`, `description`) VALUES
(1, 'public', 'Iedereen'),
(2, 'volunteer', 'Vrijwilliger'),
(3, 'colleague', 'Medewerker (alleen lezen)'),
(4, 'writing_colleague', 'Medewerker (lezen en schrijven)'),
(5, 'caretaker', 'Dierverzorger');

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `id` int(10) UNSIGNED NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 1,
  `category_id` int(10) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`id`, `active`, `category_id`, `name`, `created_at`, `updated_at`) VALUES
(1, 1, 2, 'Bibi', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(2, 1, 2, 'Fleur', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(3, 1, 3, 'Mara', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(4, 1, 3, 'Margriet', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(5, 1, 3, 'Luna', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(6, 1, 5, 'Otje', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(7, 1, 5, 'Dotje', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(8, 1, 6, 'Bestellingen bij Eemland veevoer', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(9, 1, 7, 'Esmee', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(10, 1, 7, 'Luuk', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(11, 1, 8, 'Jan', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(12, 1, 9, 'Klussenlijst Tuin', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(13, 1, 9, 'Klussenlijst Terrein', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(23, 1, 1, 'Daffy', '2019-09-12 12:31:28', '2019-09-12 12:31:28'),
(24, 1, 1, 'Donald', '2019-09-12 12:31:28', '2019-09-12 12:31:28');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` varchar(50) NOT NULL,
  `color` int(10) UNSIGNED NOT NULL DEFAULT 1,
  `role` int(10) UNSIGNED NOT NULL DEFAULT 2,
  `active` tinyint(1) NOT NULL DEFAULT 1,
  `last_logout` datetime NOT NULL DEFAULT current_timestamp(),
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `encrypted_password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `username`, `color`, `role`, `active`, `last_logout`, `created_at`, `updated_at`, `encrypted_password`) VALUES
(1, 'Karin', 1, 5, 1, '2019-10-25 10:09:07', NULL, NULL, '$2y$10$Cq0ahearwuGJULLvKHuTNub73VCfPH4yzzJHS.91c1rehLqjOiV8e'),
(2, 'Marco', 2, 5, 1, '2018-08-06 11:57:34', NULL, NULL, '$2y$10$L4WAtU2zE/mDVIlU6fAW0.TgKtTXAS53ZTMiFJSsF92NKXAxDtnJO'),
(3, 'Thea', 3, 4, 1, '2019-10-14 12:39:05', NULL, NULL, '$2y$10$MPNILEuqjJPeUGMS/8LxOeurRfWnEofQf.ZmSq9KeDU6KdMdTE0iO'),
(4, 'Diederik', 4, 3, 1, '2019-10-18 11:26:56', NULL, NULL, '$2y$10$wIA9OmDdyFTestaBjoHtDeYEs47hN0NRUMLy0EQprdkbwGjin4qGq'),
(5, 'Jan', 5, 2, 1, '2019-10-14 11:54:20', NULL, NULL, '$2y$10$2Khe3FUeWzSdIYfdHobM7OEeKHzZ0rvDZvbvcPVwQ92/eLNQMGYUe'),
(6, 'Maartje_', 1, 5, 1, '2019-10-25 10:06:18', NULL, NULL, '$2y$10$kD/SCdQ.drJwxA28DAAl4OJuQyDqJv6GWVW04MU7p7qqd6PUjlakG');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `colors`
--
ALTER TABLE `colors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `comment_user_id_foreign` (`user_id`) USING BTREE,
  ADD KEY `comment_message_id_foreign` (`message_id`) USING BTREE;

--
-- Indexes for table `field_data`
--
ALTER TABLE `field_data`
  ADD PRIMARY KEY (`id`),
  ADD KEY `field_data_subject_id_foreign` (`subject_id`) USING BTREE,
  ADD KEY `field_data_field_id_foreign` (`field_id`) USING BTREE;

--
-- Indexes for table `field_per_category`
--
ALTER TABLE `field_per_category`
  ADD PRIMARY KEY (`id`),
  ADD KEY `field_per_category_field_id_foreign` (`field_id`) USING BTREE,
  ADD KEY `field_per_category_category_id_foreign` (`category_id`) USING BTREE;

--
-- Indexes for table `field_table`
--
ALTER TABLE `field_table`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`),
  ADD KEY `message_subject_id_foreign` (`subject_id`) USING BTREE,
  ADD KEY `message_visible_for_role_id_foreign` (`visible_for_role_id`) USING BTREE,
  ADD KEY `message_category_id_foreign` (`category_id`) USING BTREE,
  ADD KEY `message_user_id_foreign` (`user_id`) USING BTREE;

--
-- Indexes for table `password_resets`
--
ALTER TABLE `password_resets`
  ADD KEY `password_resets_email_index` (`email`) USING BTREE;

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`id`),
  ADD KEY `subject_category_id_foreign` (`category_id`) USING BTREE;

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user_username_unique` (`username`),
  ADD KEY `user_role_foreign` (`role`) USING BTREE,
  ADD KEY `user_color_foreign` (`color`) USING BTREE;

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `colors`
--
ALTER TABLE `colors`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `field_data`
--
ALTER TABLE `field_data`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `field_per_category`
--
ALTER TABLE `field_per_category`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `field_table`
--
ALTER TABLE `field_table`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `message`
--
ALTER TABLE `message`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `comment`
--
ALTER TABLE `comment`
  ADD CONSTRAINT `comment_message_id_foreign` FOREIGN KEY (`message_id`) REFERENCES `message` (`id`),
  ADD CONSTRAINT `comment_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `field_data`
--
ALTER TABLE `field_data`
  ADD CONSTRAINT `field_data_field_id_foreign` FOREIGN KEY (`field_id`) REFERENCES `field_table` (`id`),
  ADD CONSTRAINT `field_data_subject_id_foreign` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`id`);

--
-- Constraints for table `field_per_category`
--
ALTER TABLE `field_per_category`
  ADD CONSTRAINT `field_per_category_category_id_foreign` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`),
  ADD CONSTRAINT `field_per_category_field_id_foreign` FOREIGN KEY (`field_id`) REFERENCES `field_table` (`id`);

--
-- Constraints for table `message`
--
ALTER TABLE `message`
  ADD CONSTRAINT `message_category_id_foreign` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`),
  ADD CONSTRAINT `message_subject_id_foreign` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`id`),
  ADD CONSTRAINT `message_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `message_visible_for_role_id_foreign` FOREIGN KEY (`visible_for_role_id`) REFERENCES `roles` (`id`);

--
-- Constraints for table `subject`
--
ALTER TABLE `subject`
  ADD CONSTRAINT `subject_category_id_foreign` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_color_foreign` FOREIGN KEY (`color`) REFERENCES `colors` (`id`),
  ADD CONSTRAINT `user_role_foreign` FOREIGN KEY (`role`) REFERENCES `roles` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

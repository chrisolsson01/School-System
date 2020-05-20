-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 21 feb 2020 kl 14:21
-- Serverversion: 10.4.6-MariaDB
-- PHP-version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `csharp_schoolsys`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `betyg`
--

CREATE TABLE `betyg` (
  `elev_namn` varchar(64) NOT NULL,
  `Svenska 1` varchar(1) NOT NULL,
  `Svenska 2` varchar(1) NOT NULL,
  `Svenska 3` varchar(1) NOT NULL,
  `Engelska 5` varchar(1) NOT NULL,
  `Engelska 6` varchar(1) NOT NULL,
  `Engelska 7` varchar(1) NOT NULL,
  `Mattematik 1b` varchar(1) NOT NULL,
  `Mattematik 2b` varchar(1) NOT NULL,
  `Mattematik 3b` varchar(1) NOT NULL,
  `Mattematik 1c` varchar(1) NOT NULL,
  `Mattematik 2c` varchar(1) NOT NULL,
  `Mattematik 3c` varchar(1) NOT NULL,
  `Mattematik 4` varchar(1) NOT NULL,
  `Mattematik 5` varchar(1) NOT NULL,
  `Idrott och Hälsa 1` varchar(1) NOT NULL,
  `Historia 1b` varchar(1) NOT NULL,
  `Historia 2b - kultur` varchar(1) NOT NULL,
  `Naturkunskap 1b` varchar(1) NOT NULL,
  `Religionkunskap` varchar(1) NOT NULL,
  `Samhällskunskap 1b` varchar(1) NOT NULL,
  `Estetisk Kommunikation 1` varchar(1) NOT NULL,
  `Konstarterna och samhället` varchar(1) NOT NULL,
  `Digitalt Skapande 1` varchar(1) NOT NULL,
  `Medieproduktion 1` varchar(1) NOT NULL,
  `Medieproduktion 2` varchar(1) NOT NULL,
  `Medier, samhälle och kommunikation` varchar(1) NOT NULL,
  `Träningslära 1` varchar(1) NOT NULL,
  `Entreprenörskap` varchar(1) NOT NULL,
  `Ljudproduktion 1` varchar(1) NOT NULL,
  `Film- och TV-produktion 1` varchar(1) NOT NULL,
  `Träningslära 2` varchar(1) NOT NULL,
  `Entreprenörskap och företagande` varchar(1) NOT NULL,
  `Naturkunskap 2` varchar(1) NOT NULL,
  `Idrott hälsa 2` varchar(1) NOT NULL,
  `Bildteori` varchar(1) NOT NULL,
  `Medier, samhälle och kommunkation 2` varchar(1) NOT NULL,
  `Idrott och hälsa specialisering 1` varchar(1) NOT NULL,
  `Idrott och hälsa specialisering 2` varchar(1) NOT NULL,
  `Gymnasiearbete` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellstruktur `elever`
--

CREATE TABLE `elever` (
  `ID` int(11) NOT NULL,
  `namn` varchar(64) NOT NULL,
  `klass` varchar(8) NOT NULL,
  `personnummer` varchar(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumpning av Data i tabell `elever`
--

INSERT INTO `elever` (`ID`, `namn`, `klass`, `personnummer`) VALUES
(23, 'Liam Olsson', 'SY17', '010803');

-- --------------------------------------------------------

--
-- Tabellstruktur `klasser`
--

CREATE TABLE `klasser` (
  `klass_id` int(11) NOT NULL,
  `klass_namn` varchar(6) NOT NULL,
  `klass_elever` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumpning av Data i tabell `klasser`
--

INSERT INTO `klasser` (`klass_id`, `klass_namn`, `klass_elever`) VALUES
(0, 'SY17', 0);

-- --------------------------------------------------------

--
-- Tabellstruktur `meddelanden`
--

CREATE TABLE `meddelanden` (
  `id` int(11) NOT NULL,
  `msg_cont` varchar(1024) NOT NULL,
  `msg_from` varchar(64) NOT NULL,
  `msg_to` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumpning av Data i tabell `meddelanden`
--

INSERT INTO `meddelanden` (`id`, `msg_cont`, `msg_from`, `msg_to`) VALUES
(1, 'test', 'System.Windows.Forms.ListBox+SelectedObjectCollection', 'System.Windows.Forms.ListBox+SelectedObjectCollection'),
(2, 'rtsea', 'SY17', 'Liam Olsson'),
(3, 'Hejsan ni har nu inget liv', 'liam.olsson', 'SY17');

-- --------------------------------------------------------

--
-- Tabellstruktur `salar`
--

CREATE TABLE `salar` (
  `id` int(11) NOT NULL,
  `namn` varchar(16) NOT NULL,
  `status` varchar(16) NOT NULL,
  `bokad_av` varchar(64) NOT NULL,
  `grupprum` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumpning av Data i tabell `salar`
--

INSERT INTO `salar` (`id`, `namn`, `status`, `bokad_av`, `grupprum`) VALUES
(1, 'A303', 'bokat', 'liam', 'ja');

-- --------------------------------------------------------

--
-- Tabellstruktur `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Username` varchar(64) NOT NULL,
  `email` varchar(64) NOT NULL,
  `Password` varchar(256) NOT NULL,
  `User_Role` varchar(16) NOT NULL,
  `User_Created` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumpning av Data i tabell `users`
--

INSERT INTO `users` (`ID`, `Username`, `email`, `Password`, `User_Role`, `User_Created`) VALUES
(2, 'liamolsson', 'liamolsson2001@gmail.com', 'test', 'admin', '2020-02-18 12:00:06'),
(7, 'liam.olsson', '', '32D321A1CFBDF2F62EB326E6298BB9470DE62FF37E51418DBC4A1F8293AFAEC5', 'elev', '2020-02-19 14:33:58');

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `betyg`
--
ALTER TABLE `betyg`
  ADD PRIMARY KEY (`elev_namn`);

--
-- Index för tabell `elever`
--
ALTER TABLE `elever`
  ADD PRIMARY KEY (`ID`);

--
-- Index för tabell `klasser`
--
ALTER TABLE `klasser`
  ADD PRIMARY KEY (`klass_id`);

--
-- Index för tabell `meddelanden`
--
ALTER TABLE `meddelanden`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `salar`
--
ALTER TABLE `salar`
  ADD PRIMARY KEY (`id`);

--
-- Index för tabell `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `elever`
--
ALTER TABLE `elever`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT för tabell `meddelanden`
--
ALTER TABLE `meddelanden`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT för tabell `salar`
--
ALTER TABLE `salar`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT för tabell `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

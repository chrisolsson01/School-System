-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Värd: 127.0.0.1
-- Tid vid skapande: 29 apr 2020 kl 17:24
-- Serverversion: 10.4.8-MariaDB
-- PHP-version: 7.3.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databas: `school_sys`
--

-- --------------------------------------------------------

--
-- Tabellstruktur `elev`
--

CREATE TABLE `elev` (
  `Namn` varchar(64) COLLATE utf8_swedish_ci NOT NULL,
  `Klass` varchar(8) COLLATE utf8_swedish_ci NOT NULL,
  `Personnummer` int(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

-- --------------------------------------------------------

--
-- Tabellstruktur `elev_schema`
--

CREATE TABLE `elev_schema` (
  `elev_personnummer` int(12) NOT NULL,
  `elev_lektion` varchar(64) COLLATE utf8_swedish_ci NOT NULL,
  `elev_lektion_sal` varchar(16) COLLATE utf8_swedish_ci NOT NULL,
  `elev_lektion_tid` varchar(32) COLLATE utf8_swedish_ci NOT NULL,
  `elev_lektion_dag` varchar(16) COLLATE utf8_swedish_ci NOT NULL,
  `elev_lektion_datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

-- --------------------------------------------------------

--
-- Tabellstruktur `klasser`
--

CREATE TABLE `klasser` (
  `elev_personnummer` int(12) NOT NULL,
  `klass_namn` varchar(8) COLLATE utf8_swedish_ci NOT NULL,
  `klass_elever` varchar(11) COLLATE utf8_swedish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

-- --------------------------------------------------------

--
-- Tabellstruktur `meddelanden`
--

CREATE TABLE `meddelanden` (
  `personnummer` int(12) NOT NULL,
  `msg_cont` varchar(256) COLLATE utf8_swedish_ci NOT NULL,
  `msg_from` varchar(64) COLLATE utf8_swedish_ci NOT NULL,
  `msg_to` varchar(64) COLLATE utf8_swedish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

-- --------------------------------------------------------

--
-- Tabellstruktur `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Username` varchar(64) COLLATE utf8_swedish_ci NOT NULL,
  `Email` varchar(64) COLLATE utf8_swedish_ci NOT NULL,
  `Password` varchar(256) COLLATE utf8_swedish_ci NOT NULL,
  `Personnummer` int(12) NOT NULL,
  `User_Role` varchar(16) COLLATE utf8_swedish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_swedish_ci;

--
-- Dumpning av Data i tabell `users`
--

INSERT INTO `users` (`ID`, `Username`, `Email`, `Password`, `Personnummer`, `User_Role`) VALUES
(1, 'liam.olsson', 'liamolsson2001@gmail.com', '32D321A1CFBDF2F62EB326E6298BB9470DE62FF37E51418DBC4A1F8293AFAEC5', 10803, 'admin');

--
-- Index för dumpade tabeller
--

--
-- Index för tabell `elev`
--
ALTER TABLE `elev`
  ADD PRIMARY KEY (`Personnummer`);

--
-- Index för tabell `elev_schema`
--
ALTER TABLE `elev_schema`
  ADD PRIMARY KEY (`elev_personnummer`);

--
-- Index för tabell `klasser`
--
ALTER TABLE `klasser`
  ADD PRIMARY KEY (`elev_personnummer`);

--
-- Index för tabell `meddelanden`
--
ALTER TABLE `meddelanden`
  ADD PRIMARY KEY (`personnummer`);

--
-- Index för tabell `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Personnummer` (`Personnummer`);

--
-- AUTO_INCREMENT för dumpade tabeller
--

--
-- AUTO_INCREMENT för tabell `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

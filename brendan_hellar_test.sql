-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 12, 2019 at 06:47 PM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `brendan_hellar_test`
--

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylistId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `client`
--
ALTER TABLE `client`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

-- --------------------------------------------------------

--
-- Table structure for table `stylist`
--

CREATE TABLE `stylist` (
`id` int(11) NOT NULL,
`name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `stylist`
--
ALTER TABLE `stylist`
ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `stylist`
--
ALTER TABLE `stylist`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
`id` int(11) NOT NULL,
`name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

-- --------------------------------------------------------

--
-- Table structure for table `stylistSpecialties`
--

CREATE TABLE `stylistSpecialties` (
`id` int(11) NOT NULL,
`stylistId` int(11) NOT NULL,
`specialtyId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `stylistSpecialties`
--
ALTER TABLE `stylistSpecialties`
ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `stylistSpecialties`
--
ALTER TABLE `stylistSpecialties`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

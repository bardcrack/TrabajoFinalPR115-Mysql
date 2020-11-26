-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-11-2020 a las 06:59:20
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `problema3pr115`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `card`
--

CREATE TABLE `card` (
  `id_card` bigint(20) NOT NULL,
  `date_created` datetime NOT NULL,
  `id_customer` bigint(20) NOT NULL,
  `id_card_type` bigint(20) NOT NULL,
  `percentage_credit` float(10,2) NOT NULL,
  `amount_credit` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `card`
--

INSERT INTO `card` (`id_card`, `date_created`, `id_customer`, `id_card_type`, `percentage_credit`, `amount_credit`) VALUES
(1, '2020-11-25 19:08:33', 10, 1, 5.00, 2500.00),
(2, '2020-11-25 23:33:48', 1, 1, 25.50, 3800.00),
(3, '2020-11-25 23:34:01', 1, 2, 25.50, 4500.00),
(4, '2020-11-25 23:56:15', 12, 3, 8.40, 600.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `card_transaction`
--

CREATE TABLE `card_transaction` (
  `id_card_transaction` bigint(20) NOT NULL,
  `date_created` datetime NOT NULL,
  `id_card` bigint(20) NOT NULL,
  `amount_transaction` float(10,2) NOT NULL,
  `points_transactions` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `card_transaction`
--

INSERT INTO `card_transaction` (`id_card_transaction`, `date_created`, `id_card`, `amount_transaction`, `points_transactions`) VALUES
(1, '2020-11-25 20:57:53', 1, 250.00, 5),
(2, '2020-11-10 00:00:00', 1, 35.00, 5),
(3, '2020-11-25 00:00:00', 1, 550.00, 20);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `card_type`
--

CREATE TABLE `card_type` (
  `id_card_type` bigint(20) NOT NULL,
  `card_name` varchar(255) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `card_type`
--

INSERT INTO `card_type` (`id_card_type`, `card_name`) VALUES
(1, 'Visa'),
(2, 'Mastercard Premium'),
(3, 'Mastercard Basic');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user`
--

CREATE TABLE `user` (
  `id_user` bigint(20) NOT NULL,
  `date_created` datetime NOT NULL DEFAULT current_timestamp(),
  `user_nickname` varchar(255) COLLATE utf8_bin NOT NULL,
  `user_email` varchar(255) COLLATE utf8_bin NOT NULL,
  `user_password` varchar(255) COLLATE utf8_bin NOT NULL,
  `user_firstname` varchar(255) COLLATE utf8_bin NOT NULL,
  `user_lastname` varchar(255) COLLATE utf8_bin NOT NULL,
  `isEmployee` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Volcado de datos para la tabla `user`
--

INSERT INTO `user` (`id_user`, `date_created`, `user_nickname`, `user_email`, `user_password`, `user_firstname`, `user_lastname`, `isEmployee`) VALUES
(1, '2020-11-24 16:54:43', 'julio', 'et02005@ues.edu.sv', 'manager', 'Julio Cesar', 'Escalante Teajda', 1),
(2, '2020-11-24 17:42:10', 'asdfasd', 'asd', 'asdf', 'dfasdfasd', 'asdf', 1),
(10, '2020-11-25 14:52:57', 'Daniela', 'daniel@gmail.com', 'asdfasdfasdf', 'Daniel', 'Francsico', 0),
(11, '2020-11-25 14:55:38', 'Amilcarsasdfas', 'Amilcar@gmail.com', 'asdfsd', 'Amilcar', 'Perez', 0),
(12, '2020-11-25 14:56:24', 'Amilcar', 'Amilcar@gmail.com', 'manager175', 'Amilcar', 'Perez', 0),
(13, '2020-11-25 14:56:33', 'Amilcar', 'Amilcar@gmail.com', 'manager175', 'Amilcar', 'Perez', 0),
(14, '2020-11-25 15:08:40', 'Petrusko', 'petro@gmail.com', 'manager175', 'anderson', 'Petroskini', 0),
(15, '2020-11-25 15:12:35', 'Alberto', 'alberto@gmail.com', 'manager', 'Alberto', 'Alberto', 0),
(16, '2020-11-25 15:13:20', 'Alex', 'alex@gmail.com', 'manage', 'Alex', 'HErnandez', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `card`
--
ALTER TABLE `card`
  ADD PRIMARY KEY (`id_card`),
  ADD KEY `id_card_type` (`id_card_type`),
  ADD KEY `id_customer` (`id_customer`);

--
-- Indices de la tabla `card_transaction`
--
ALTER TABLE `card_transaction`
  ADD PRIMARY KEY (`id_card_transaction`),
  ADD KEY `id_card` (`id_card`);

--
-- Indices de la tabla `card_type`
--
ALTER TABLE `card_type`
  ADD PRIMARY KEY (`id_card_type`);

--
-- Indices de la tabla `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `card`
--
ALTER TABLE `card`
  MODIFY `id_card` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `card_transaction`
--
ALTER TABLE `card_transaction`
  MODIFY `id_card_transaction` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `card_type`
--
ALTER TABLE `card_type`
  MODIFY `id_card_type` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `user`
--
ALTER TABLE `user`
  MODIFY `id_user` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `card`
--
ALTER TABLE `card`
  ADD CONSTRAINT `card_ibfk_1` FOREIGN KEY (`id_card_type`) REFERENCES `card_type` (`id_card_type`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `card_ibfk_2` FOREIGN KEY (`id_customer`) REFERENCES `user` (`id_user`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `card_transaction`
--
ALTER TABLE `card_transaction`
  ADD CONSTRAINT `card_transaction_ibfk_1` FOREIGN KEY (`id_card`) REFERENCES `card` (`id_card`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `card_transaction_ibfk_2` FOREIGN KEY (`id_card`) REFERENCES `card` (`id_card`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

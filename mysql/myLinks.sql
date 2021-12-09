SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

-- Database: `tolga_launchPad`


-- Creating tables
CREATE TABLE `tblLink` (
  `linkID` int(100) NOT NULL,
  `categoryID` int(10) NOT NULL,
  `label` varchar(50) NOT NULL,
  `pinned` int(1) NOT NULL,
  `url` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

CREATE TABLE `tblCategory` (
  `categoryID` int(10) NOT NULL,
  `categoryName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE `tblUser` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;



-- Inserting data into tables 
INSERT INTO `tblLink` (`linkID`,`categoryID`,`label`,`pinned`,`url`) VALUES
(1, 2, 'Angular API',0,'https://angular.io/api'),
(2, 2, 'Block Element Modifier',1,'http://getbem.com'),
(3, 2, 'CreateJS Home',1,'http://www.createjs.com/'),
(4, 3, 'AWS Academy Main Portal',0,'https://teams.microsoft.com/_?culture=en-ca&amp;country=CA&amp;lm=deeplink&amp;lmsrc=homePageWeb&amp;cmpid=WebSignIn'),
(5, 3, 'MS Teams',0,'https://angular.io/api'),
(6, 3, 'NSCC Brightspace',0,'https://nscconline.desire2learn.com/'),
(7, 6, 'Amazon Prime Video',0,'https://www.primevideo.com/'),
(8, 6, 'CBC Gem',0,'https://gem.cbc.ca/'),
(9, 18, 'Blue Cross Insurance',0,'https://www.medaviebc.ca/en/support/login'),
(10, 18, 'Environment Canada Weather',1,'http://weather.gc.ca/city/pages/ns-19_metric_e.html'),
(11, 18, 'Floorplanner',0,'https://floorplanner.com/');

INSERT INTO `tblCategory` (`categoryID`, `categoryName`) VALUES
(2, 'Technology'),
(3, 'School'),
(6, 'Play'),
(18, 'Data');

INSERT INTO `tblUser` (`username`, `password`, `salt`) VALUES
('user', 'uLzOc9hqo47A75r1r9TE3ZctD3qmWEA4oQip4zfpgMg=', 'KUgMBBIZbPDsMiGUOc1UvQ=='),
('tolga', 'QaE2xz4dlYR9L7vOMZoUQN7+ObrBFeot/80jaOsTZYk=', 'gMSXu/y60KCrgWqHdRxrbQ==');



-- Indexes for dumped tables 
ALTER TABLE `tblCategory`
  ADD PRIMARY KEY (`categoryID`);

ALTER TABLE `tblLink`
  ADD PRIMARY KEY (`linkID`),
  ADD KEY `categoryID` (`categoryID`);


-- AUTO_INCREMENT for dumped tables 
ALTER TABLE `tblCategory`
  MODIFY `categoryID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

ALTER TABLE `tblLink`
  MODIFY `linkID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;


-- Constraints for dumped tables 
ALTER TABLE `tblLink`
  ADD CONSTRAINT `tblLink_ibfk_1` FOREIGN KEY (`categoryID`) REFERENCES `tblCategory` (`categoryID`) ON DELETE CASCADE ON UPDATE CASCADE;



SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `university` DEFAULT CHARACTER SET utf8 ;
USE `university` ;

-- -----------------------------------------------------
-- Table `university`.`course`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`course` (
  `id` INT(11) NOT NULL ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`course_student`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`course_student` (
  `id` INT(11) NOT NULL ,
  `_student_id` INT NOT NULL ,
  `_course_id` INT NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`department`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`department` (
  `id` INT(11) NOT NULL ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`department_course`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`department_course` (
  `id` INT(11) NOT NULL ,
  `_course_id` INT(11) NOT NULL ,
  `_deparment_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`department_profesor`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`department_profesor` (
  `id` INT(11) NOT NULL ,
  `_department_id` INT(11) NOT NULL ,
  `_profesor_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`faculty`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`faculty` (
  `id` INT(11) NOT NULL ,
  `first` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`faculty_department`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`faculty_department` (
  `id` INT(11) NOT NULL ,
  `_faculty_id` INT(11) NOT NULL ,
  `_department_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`profesor`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`profesor` (
  `id` INT(11) NOT NULL ,
  `firt_name` VARCHAR(45) NULL DEFAULT NULL ,
  `last_name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`profesor_course`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`profesor_course` (
  `id` INT(11) NOT NULL ,
  `_profesor_id` INT(11) NOT NULL ,
  `_course_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`profesor_title`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`profesor_title` (
  `id` INT(11) NOT NULL ,
  `_profesor_id` INT(11) NOT NULL ,
  `_title_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`student`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`student` (
  `id` INT(11) NOT NULL ,
  `fist_name` VARCHAR(45) NULL DEFAULT NULL ,
  `last_name` VARCHAR(45) NULL DEFAULT NULL ,
  `_faculty_id` INT NOT NULL ,
  `course_student_id` INT(11) NOT NULL ,
  PRIMARY KEY (`id`, `course_student_id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `university`.`title`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `university`.`title` (
  `id` INT(11) NOT NULL ,
  `name` VARCHAR(45) NULL DEFAULT NULL ,
  PRIMARY KEY (`id`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

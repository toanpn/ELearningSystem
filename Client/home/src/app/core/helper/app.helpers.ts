import { VariablesConstant } from 'src/app/core/constants/variables.constant';




/*
 * Inspinia js helpers:
 *
 * correctHeight() - fix the height of main wrapper
 * detectBody() - detect windows size
 * smoothlyMenu() - add smooth fade in/out on navigation show/ide
 *
 */

declare var jQuery: any;

export function correctHeight() {

  const pageWrapper = jQuery('#page-wrapper');
  const navbarHeight = jQuery('nav.navbar-default').height();
  const wrapperHeight = pageWrapper.height();

  if (navbarHeight > wrapperHeight) {
    pageWrapper.css('min-height', navbarHeight + 'px');
  }

  if (navbarHeight <= wrapperHeight) {
    if (navbarHeight < jQuery(window).height()) {
      pageWrapper.css('min-height', jQuery(window).height() + 'px');
    } else {
      pageWrapper.css('min-height', navbarHeight + 'px');
    }
  }

  if (jQuery('body').hasClass('fixed-nav')) {
    if (navbarHeight > wrapperHeight) {
      pageWrapper.css('min-height', navbarHeight + 'px');
    } else {
      pageWrapper.css('min-height', jQuery(window).height() - 60 + 'px');
    }
  }
}

export function detectBody() {
  if (jQuery(document).width() < 769) {
    jQuery('body').addClass('body-small');
  } else {
    jQuery('body').removeClass('body-small');
  }
}

export function smoothlyMenu() {
  if (!jQuery('body').hasClass('mini-navbar') || jQuery('body').hasClass('body-small')) {
    // Hide menu in order to smoothly turn on when maximize menu
    jQuery('#side-menu').hide();
    // For smoothly turn on menu
    setTimeout(
      () => {
        jQuery('#side-menu').fadeIn(400);
      }, 200);
  } else if (jQuery('body').hasClass('fixed-sidebar')) {
    jQuery('#side-menu').hide();
    setTimeout(
      () => {
        jQuery('#side-menu').fadeIn(400);
      }, 100);
  } else {
    // Remove all inline style from jquery fadeIn function to reset menu state
    jQuery('#side-menu').removeAttr('style');
  }
}

export function checkValidDate(dateString: string){
  if (new Date(dateString).toString() === 'Invalid Date' ) return false;
  const month = parseInt(dateString.split('/')[0])
  const date = parseInt(dateString.split('/')[1])
  const year = parseInt(dateString.split('/')[2])

  const isLeap = ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)
  const checkNumberOfDays = 
    ((month === 1 || month === 3 || month === 5 || month === 7 || month === 8 || month === 10 || month === 12) && date <= 31) ||
    ((month === 4 || month === 6 || month === 9 || month === 11) && date <= 30) || 
    (month === 2 && date <= 28 && !isLeap) || (month === 2 && date <= 29 && isLeap)

  return checkNumberOfDays;
}

export function limitLengthYear(dateString: any){
  const value = dateString.target.value
  if ((isNaN(parseInt(dateString.data)) && dateString.data !== null && dateString.data !== '/') || (value.split('/')[2].length === 5)){
        return value.substring(0, value.length-1)
      }

  return value;
}

export function checkValidDateTime(datetimeString: string){
  if (new Date(datetimeString).toString() === 'Invalid Date') return false;
  const dateString = datetimeString.split(',')[0]
  const month = parseInt(dateString.split('/')[0])
  const date = parseInt(dateString.split('/')[1])
  const year = parseInt(dateString.split('/')[2])

  const isLeap = ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)
  const checkNumberOfDays = 
    ((month === 1 || month === 3 || month === 5 || month === 7 || month === 8 || month === 10 || month === 12) && date <= 31) ||
    ((month === 4 || month === 6 || month === 9 || month === 11) && date <= 30) || 
    (month === 2 && date <= 28 && !isLeap) || (month === 2 && date <= 29 && isLeap)

  return checkNumberOfDays;
}

export function limitLengthYearTime(dateString: any){
  const value = dateString.target.value
  const date = value.split(',')[0]
  const time = value.split(',')[1]
  if (date.split('/')[2].length === 5){
        return date.substring(0, date.length-1).concat(',').concat(time)
      }

  return value;
}

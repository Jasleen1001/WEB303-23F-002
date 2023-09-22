/*
	WEB 303 Assignment 1 - jQuery
	Jasleen Kaur Braich
*/

$(document).ready(function(){
	$("#year-salary,#percent").on('keyup',function(){
		var yearly = parseFloat($('#yearly-salary').val());
		var percent = parseFloat($('#percent').val());
		var spending= ((yearly*percent)/100).toFixed(2);
		$('#amount').text("$ "+spending);

	})
});

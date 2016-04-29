








$(function(){


    $(document).on("mouseenter", ".select-box", function(){

        var parent = $(this);
        var select_option = parent.find(".select-option");
        select_option.show();
    });

    $(document).on("mouseleave", ".select-box", function(){

        var parent = $(this);
        var select_option = parent.find(".select-option");
        select_option.hide();
    });

    $(document).on("click", "#agent0", function () {

        var agent0 = $(this);
        var agent1 = $("#agent1");

        if(!agent0.hasClass("rent-on")){
            agent1.removeClass("rent-on").addClass("rent-mode");
            agent0.removeClass("rent-mode").addClass("rent-on");
        }

    });

    $(document).on("click", "#agent1", function () {

        var agent0 = $("#agent0");
        var agent1 = $(this);

        if(!agent1.hasClass("rent-on")){
            agent0.removeClass("rent-on").addClass("rent-mode");
            agent1.removeClass("rent-mode").addClass("rent-on");
        }

    });


});

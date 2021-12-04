
//UNDERGRAD SECTION*********************************************************0
getData({path:'/degrees/undergraduate'}).done(function(output){
   //console.log(output);
   $.each(output.undergraduate,function(index,value){
      var head = value.title;
      var desc = value.description;
      $("#under").append($("<h3></h3>").attr("id","chead"+index));
      $("#chead"+index).append(head);
      $("#under").append($("<div></div>").attr("id","cdesc"+index).append($("<p></p>").attr("id","cpdesc").append(desc)));
      $("#cpdesc").append($("<ol></ol>").attr("id","ol"+index));
  });
   $(function(){
      $("#under").accordion();
   });
});
//END OF UNDERGRAD**********************************************************

//GRADUTE section**********************************************************
getData({path:'/degrees/graduate'}).done(function(output){
   //console.log(output);
   $.each(output.graduate,function(index,value){
      var head = value.title;
      var desc = value.description;
      $("#grad").append($("<h3></h3>").attr("id","cheadg"+index));
      $("#cheadg"+index).append(head);
      $("#grad").append($("<div></div>").attr("id","cdescg"+index).append($("<p></p>").attr("id","cpdescg").append(desc)));
      $("#cpdescg").append($("<ol></ol>").attr("id","ol"+index));
  });
  $("#cheadg"+3).hide();
  $("#cdescg"+3).hide();
   $(function(){
      $("#grad").accordion();
   });
});
//END OF GRADUATE**********************************************************

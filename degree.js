/**
     * Degrees
     */
    xhr('get', {path:"/degrees/"}, '#degrees').done(function(results){

        // Undergraduate
        $.each(results.undergraduate, function(){
            // Front Modal - Back will only be loaded if clicked on
            var frontModal = '<a href="#mainModal" rel="modal:open" class="degree-anchor">' +
                                '<div class="uDegBoxes" data-degree="'+ this.degreeName +'">'+
                                    '<p class="degree-name">' + this.title + '</p>' +
                                    '<p class="degree-Desc">' + this.description + '</p>' +
                                    '<i class="far fa-plus-square"></i>' +
                                '</div>' +
                            '</a>';

            //Append to dom
            $('#tabs-1').append(frontModal); // The modal itself - front
       });


       // Graduate
       $.each(results.graduate, function(){
            // Only make ones that have a title
            if(this.title){
                // Only showing front modal until clickec on
                var frontModal = '<a href="#mainModal" rel="modal:open" class="degree-anchor">' +
                                    '<div class="gDegBoxes" data-degree="'+ this.degreeName +'">'+
                                        '<p class="degree-name">' + this.title + '</p>' +
                                        '<p class="degree-Desc">' + this.description + '</p>' +
                                        '<i class="far fa-plus-square"></i>' +
                                    '</div>' +
                                '</a>';

                $('#tabs-2').append(frontModal); // append front
            }  
            else{
                // Case of only degree without a title
                // It's the certificates section
                var certificates = '<div id="certificates-container">' +
                        '<h1>' + this.degreeName + '</h1><i class="fas fa-award"></i>';

                $.each(this.availableCertificates, function(index, elem){
                    certificates += '<p>' + elem + '</p>';
                });
                certificates += '</div>';
                $('#degrees').append(certificates);
            }
       });


      
       

        // Now get the information for this object
        $('.uDegBoxes').on('click', function(){
            // Pass in the query 'results.undergraduate' and the data attribute value
            buildDegreeBackModal(results.undergraduate, $(this).attr('data-degree'));
        });

        // Now get the information for this object
        $('.gDegBoxes').on('click', function(){
            // Pass in the query 'results.undergraduate' and the data attribute value
            buildDegreeBackModal(results.graduate, $(this).attr('data-degree'));
        });
    });

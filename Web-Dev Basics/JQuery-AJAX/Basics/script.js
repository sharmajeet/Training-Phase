$(document).ready(function(){ 
     
    let fetchBtn = $('#fetchBtn');
    fetchBtn.click(function buttonClickHandler(){ 

        // Instantiate an xhr object
        const xhr = new XMLHttpRequest();

        // Readystate 
        xhr.readyStateChange = function(){
            console.log('Ready state is ', xhr.readyState);
        }

        // Open the object
        xhr.open('GET', './Demo.txt', true);

        // What to do on progress (optional)
        xhr.onprogress = function(){
            console.log('On progress');
        }

       

        // What to do when response is ready
        xhr.onload = function() {
           if(this.status === 200)
           {
            console.log(this.responseText);
           }else{
                console.log('Some error occured');
           }
        }

        // Send the request
        xhr.send();
    });
});
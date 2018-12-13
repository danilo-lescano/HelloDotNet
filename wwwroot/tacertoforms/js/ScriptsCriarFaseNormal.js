var ScriptsCriarFaseNormal = {
    listaDeDesafios: [],
    quantidade: 0,
    correto: false,
    desafio: function(id, palavra, eCorreto, faseId, significado, dica){
        this.id = id;
        this.palavra = palavra;
        this.eCorreto = eCorreto;
        this.faseId = faseId;
        this.significado = significado;
        this.dica = dica;
    
    },
    addPalavra: function(){

        let palavra = this.checaPalavra();

        if(palavra != 0){
            let cor = this.pegaCor();

            let palavrasContainer = document.getElementById('palavrasAdicionadas');
            palavrasContainer.innerHTML += '<div class="palavraBox '+cor+'"><h6>'+palavra+'</h6></div>';
            let significado = document.getElementById('textoSignificado').value;
            let dica = document.getElementById('textoDica').value;
            
            this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade-1, palavra, this.correto, significado, dica);
            console.log(this.listaDeDesafios[this.quantidade - 1]);
        }else{
            console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
            this.mostraToast(1);
        }
    },
    checaPalavra: function(){
        let palavra = document.getElementById('palavraText').value;
        document.getElementById('palavraText').value = "";
        
        if(palavra != false)
            return palavra;
        return 0;
    },
    mostraToast: function(op){
        
        if(op == 1){
            //Materialize.toast('I am a toast!', 3000, 'blue rounded');
            M.toast({html: 'Você precisa digitar uma palavra!', classes: 'rounded red ssspalavraFaltandoModoNormal'});
        }
    },
    pegaCor: function(){
        let radios = document.getElementsByName('alternativaPalavra');
        let cor = "green";
        if(radios[0].checked){
            this.correto = true;
        }else if(radios[1].checked){
            cor = "red";
            this.correto = false;
        }    

        return cor;
    }
}
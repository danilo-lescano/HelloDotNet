var ScriptsCriarFaseNormal = {
    listaDeDesafios: [],
    quantidade: 0,
    correto: false,
    editando: -1,
    desafio: function(id, palavra, eCorreto, faseId, significado, dica){
        this.id = id;
        this.palavra = palavra;
        this.eCorreto = eCorreto;
        this.faseId = faseId;
        this.significado = significado;
        this.dica = dica;
    
    },
    palavraTextEdit: "",
    radioResposta: "",
    significadoTextEdit: "",
    dicaTextEdit: "",
    palavrasContainer: "",
    iframe: "",
    elemento: "", // Elemento que está sendo editado
    loadData: function(){
        console.log("sdfsdfsdfs");
        this.palavraTextEdit = document.getElementById('palavraText');
        this.radioResposta = document.getElementsByName('alternativaPalavra');
        this.significadoTextEdit = document.getElementById('textoSignificado');
        this.dicaTextEdit = document.getElementById('textoDica');
        this.palavrasContainer = document.getElementById('palavrasAdicionadas');

        this.iframe = document.getElementById('normalIframe');
        this.palavraTextEdit.focus();  
        
    },
    addPalavra: function(){

        let palavra = this.checaPalavra();

        if(palavra != 0){

            if(this.palavraNaoExiste(palavra) || this.editando >= 0){

                let cor = this.pegaCor(); // Pega a cor caso a palavra esteja certa ou errada

                let significado = this.significadoTextEdit.value;
                this.significadoTextEdit.value = "";

                let dica = this.dicaTextEdit.value;
                this.dicaTextEdit.value = "";

                if(this.editando == -1){ // Não está editando

                    let palavrasContainer = this.palavrasContainer;
                    palavrasContainer.innerHTML += '<div id = "' + this.quantidade+'" class="palavraBox '+cor+'" onclick="ScriptsCriarFaseNormal.carregaParaEditar(this.id)"><h6>'+palavra+'</h6></div>';
                    
                    this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade-1, palavra, this.correto, -1, significado, dica);
                    console.log(this.listaDeDesafios[this.quantidade - 1]);

                    document.getElementById('numeroDePalavras').innerHTML = this.quantidade;

                    this.mostraToast(2);        
                }else{ // Está editando
                
                    // var elemento = document.getElementById(this.editando); // Elemento que estou editando

                    if(this.listaDeDesafios[this.editando].palavra != palavra){
                        this.elemento.childNodes[0].innerHTML = palavra;
                        this.listaDeDesafios[this.editando].palavra = palavra; 
                    }
                    
                    if(this.listaDeDesafios[this.editando].eCorreto == true){
                        if(this.correto == false){
                            this.elemento.classList.remove("green");
                            this.elemento.classList.add("red");
                            this.listaDeDesafios[this.editando].eCorreto = this.correto;
                        }
                    }else{
                        if(this.correto == true){
                            this.elemento.classList.remove("red");
                            this.elemento.classList.add("green");
                            this.listaDeDesafios[this.editando].eCorreto = this.correto;
                        }
                    }
                        
                    this.listaDeDesafios[this.editando].significado = significado;
                    this.listaDeDesafios[this.editando].dica = dica;

                    this.editando = -1;

                    this.elemento.classList.remove("editandoPalavraModoNormal");

                    this.mostraToast(3);    
                }
            }else{
                this.mostraToast(4);    
            }
        }else{
            console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
            this.mostraToast(1);
        }

        this.palavraTextEdit.focus();
    },
    checaPalavra: function(){
        let palavra = this.palavraTextEdit.value;
        this.palavraTextEdit.value = "";
        
        if(palavra != false)
            return palavra;
        return 0;
    },
    mostraToast: function(op){
        
        if(op == 1){ // Pessoa não digitou uma palavra
            //Materialize.toast('I am a toast!', 3000, 'blue rounded');
            M.toast({html: 'Você precisa digitar uma palavra!', classes: 'rounded red lighten-1 palavraFaltandoModoNormal'});
        }else if(op == 2){ // Palavra foi adicionada
            M.toast({html: 'Palavra adicionada!', classes: 'rounded green lighten-1'});
        }else if(op == 3){ // Palavra foi adicionada
            M.toast({html: 'Palavra modificada!', classes: 'rounded lime'});
        }else if(op == 4){ // Palavra foi adicionada
            M.toast({html: 'Palavra já foi adicionada!', classes: 'rounded red lighten-1'});
        }
    },
    pegaCor: function(){
        let cor = "green";
        if(this.radioResposta[0].checked){
            this.correto = true;
        }else if(this.radioResposta[1].checked){
            cor = "red";
            this.correto = false;
            this.radioResposta[0].checked = true;
        }    

        return cor;
    },
    carregaParaEditar: function(id_clicado){
        this.editando = id_clicado;
        elementos = this.listaDeDesafios[this.editando];

        this.elemento = document.getElementById(this.editando); // Elemento que estou editando

        this.elemento.classList.add("editandoPalavraModoNormal");

        console.log("estou editando = "+ this.editando);
        console.log(elementos);

        document.getElementById('palavraText').value = elementos.palavra;
        if(elementos.eCorreto == true){
            this.radioResposta[0].checked = true;
        }else{
            this.radioResposta[1].checked = true;
        }

        if(elementos.significado == undefined)
            this.significadoTextEdit.value = "";
        else
            this.significadoTextEdit.value = elementos.significado;

        if(elementos.dica == undefined)
            this.dicaTextEdit.value = "";
        else
            this.dicaTextEdit.value = elementos.dica;

        this.palavraTextEdit.focus();        
        
    },
    trocaTextoPalavra: function(palavra){
        let innerDoc = (this.iframe.contentDocument) ? this.iframe.contentDocument : this.iframe.contentWindow.document;
        innerDoc.getElementById('palavra').innerHTML = palavra;
    },
    palavraNaoExiste: function(palavra){
        let naoexiste = true;
        console.log("ver se a palavra já foi adicionada");
        for(let i = 0; i < this.quantidade && naoexiste; i++){
            if(palavra.toLowerCase() == this.listaDeDesafios[i].palavra.toLowerCase())
                naoexiste = false;
        }

        return naoexiste;
    }
}

window.onload = ()=>{
    ScriptsCriarFaseNormal.loadData();
};
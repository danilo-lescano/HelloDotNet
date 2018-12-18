var ScriptsCriarFaseNormal = {
    listaDeDesafios: [],
    quantidade: 0,
    correto: false,
    editando: -1,
    desafio: function(index, id, palavra, eCorreto, faseId, significado, dica){
        this.index = index,
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
    iframe: null,
    elemento: null, // Elemento que está sendo editado
    botaoAdd: null, // Elemento do botão de Adicionar palavra
    botaoEdit: null, // Elemento do botão de Editar palavra
    botaoSave: null, // Elemento do botão de Salvar fase
    botaoDeletar: null, // Elemento do botão de Deletar palavra
    loadData: function(){
        console.log("sdfsdfsdfs");
        this.palavraTextEdit = document.getElementById('palavraText');
        this.radioResposta = document.getElementsByName('alternativaPalavra');
        this.significadoTextEdit = document.getElementById('textoSignificado');
        this.dicaTextEdit = document.getElementById('textoDica');
        this.palavrasContainer = document.getElementById('palavrasAdicionadas');

        this.botaoAdd = document.getElementById('botaoAdd');
        this.botaoEdit = document.getElementById('botaoEdit');
        this.botaoSave = document.getElementById('botaoSave');
        this.botaoDeletar = document.getElementById('botaoApagar');
        
        this.iframe = document.getElementById('normalIframe');
        this.palavraTextEdit.focus();  
        
    },
    addPalavra: function(){

        let palavra = this.checaPalavra();

        if(palavra != 0){

            if(this.palavraNaoExiste(palavra) || this.editando >= 0){

                let cor = this.pegaCor(); // Pega a cor caso a palavra esteja certa ou errada

                let significado = this.significadoTextEdit.value;

                let dica = this.dicaTextEdit.value;

                if(this.editando == -1){ // Não está editando

                    let palavrasContainer = this.palavrasContainer;
                    palavrasContainer.innerHTML += '<div id = "' + this.quantidade+'" class="palavraBox '+cor+'" onclick="ScriptsCriarFaseNormal.carregaParaEditar(this.id)"><h6>'+palavra+'</h6></div>';
                    
                    this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, this.quantidade-1, palavra, this.correto, -1, significado, dica);

                    document.getElementById('numeroDePalavras').innerHTML = this.quantidade;

                    this.mostraToast(2); // Palavra adicionada

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

                    this.estaEditando(0);

                    this.mostraToast(3); // Palavra editada   
                }

                this.limpaElementos();

            }else{
                this.mostraToast(4);    
            }
        }else{
            console.log("Chama o toast para o usuario lembrar que tem que escrever uma palavra");
            this.mostraToast(1); // Usuário não escreveu uma palavra
        }

        this.palavraTextEdit.focus();

        this.mostraBotaoSalvar();
    },
    checaPalavra: function(){
        let palavra = this.palavraTextEdit.value;
        
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
        }else if(op == 3){ // Palavra foi modificada
            M.toast({html: 'Palavra modificada!', classes: 'rounded lime'});
        }else if(op == 4){ // Palavra já foi adicionada
            M.toast({html: 'Palavra já foi adicionada!', classes: 'rounded red lighten-1'});
        }else if(op == 5){ // Palavra foi removida
            M.toast({html: 'Palavra foi removida!', classes: 'rounded red lighten-1'});
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
        if(this.editando >= 0){ // Já tem alguém editando logo devo mudar
            this.elemento.classList.remove("editandoPalavraModoNormal");         
        }

        this.editando = parseInt(id_clicado);
            
        elementos = this.listaDeDesafios[this.editando];

        this.elemento = document.getElementById(this.editando); // Elemento que estou editando

        this.elemento.classList.add("editandoPalavraModoNormal");

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

        this.estaEditando(1); 
                        
    },
    trocaTextoPalavra: function(palavra){
        let innerDoc = (this.iframe.contentDocument) ? this.iframe.contentDocument : this.iframe.contentWindow.document;
        innerDoc.getElementById('palavra').innerHTML = palavra;
    },
    palavraNaoExiste: function(palavra){
        let naoexiste = true;

        for(let i = 0; i < this.quantidade && naoexiste; i++){
            if(palavra.toLowerCase() == this.listaDeDesafios[i].palavra.toLowerCase())
                naoexiste = false;
        }

        return naoexiste;
    },
    mostraBotaoSalvar: function(){

        if(this.quantidade == 0){
            this.botaoSave.classList.add("ghostElement");
        }else if(this.quantidade == 1){
            this.botaoSave.classList.remove("ghostElement");
        }
    },
    apagarPalavra: function(){
        let indexParaApagar = this.editando;
        console.log(this.listaDeDesafios);

        this.elemento.parentNode.removeChild(this.elemento);

        console.log("dEVOO APAGAR: " + indexParaApagar + "   olha a quantidade atual = "+ this.quantidade);
        if(this.editando >= 0 && this.editando < this.quantidade-1){
            console.log("apagar alguem sem ser o ultimo");
            for(var i = this.editando; i < this.quantidade-1; ++i){
                console.log(this.listaDeDesafios);
                var aux = this.listaDeDesafios[i+1];
                console.log((i+1)+ "    "+aux + "       " + this.listaDeDesafios[i+1]);
                this.listaDeDesafios[i] =  new this.desafio(aux.index-1, aux.id-1, aux.palavra, aux.eCorreto, aux.faseId, aux.significado, aux.dica);
                document.getElementById(i+1).id = i;
            }
        }

        this.quantidade -= 1;
        this.listaDeDesafios.length = this.quantidade;
        this.editando = -1;

        console.log(this.listaDeDesafios);

        this.limpaElementos();
        this.estaEditando(0);
        this.mostraToast(5);
    },
    estaEditando: function(op){ 
        if(op > 0){ // Está 
            // Dá display num botão e tira o display do outro
            this.botaoAdd.classList.add("ghostElement");
            this.botaoEdit.classList.remove("ghostElement");
            this.botaoDeletar.classList.remove("ghostElement");
            this.botaoSave.classList.add("ghostElement");

        }else if(op == 0){ // Não está  
            this.editando = -1; 
            this.botaoAdd.classList.remove("ghostElement"); 
            this.botaoEdit.classList.add("ghostElement"); 
            this.botaoDeletar.classList.add("ghostElement"); 
            this.botaoSave.classList.remove("ghostElement"); 
            this.elemento.classList.remove("editandoPalavraModoNormal");
        } 

        this.palavraTextEdit.focus(); 

    },
    limpaElementos: function(){
        this.palavraTextEdit.value = "";
        this.radioResposta[0].checked = true;
        this.significadoTextEdit.value = "";
        this.dicaTextEdit.value = "";
    }
}

window.onload = ()=>{
    ScriptsCriarFaseNormal.loadData();
};
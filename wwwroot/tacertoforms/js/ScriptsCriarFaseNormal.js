var ScriptsCriarFaseNormal = {
    listaDeDesafios: [],
    quantidade: 0,
    correto: false,
    editando: -1,
    desafio: function(index, id, palavra, eCorreto, faseId, significado, dica){
        if(index !== null)
            this.index = index;
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
    
    // Pega as referências necessárias para o funcionamento das demais funcões
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

    // Adiciona uma palavra na fase atual
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

    // Checa se uma palavra foi escrita
    checaPalavra: function(){
        let palavra = this.palavraTextEdit.value;
        
        if(palavra != false)
            return palavra;
        return 0;
    },

    // Mostra toast
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
    // Retorna a cor do div da palavra para mostrar se ela é certa ou errada
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
    // Carrega os dados para serem editados
    carregaParaEditar: function(id_clicado){
        if(this.editando >= 0){ // Já tem alguém editando logo devo mudar
            this.elemento.classList.remove("editandoPalavraModoNormal");         
        }

        this.editando = parseInt(id_clicado); // Pega o id da div que foi clicada para saber quem será editado
            
        elementos = this.listaDeDesafios[this.editando]; // Pega os elementos que serão editados

        this.elemento = document.getElementById(this.editando); // Elemento que estou editando

        this.elemento.classList.add("editandoPalavraModoNormal"); // Adiciona classe na div clicada para mostra que está sendo editada

        document.getElementById('palavraText').value = elementos.palavra;

        if(elementos.eCorreto == true)
            this.radioResposta[0].checked = true;
        else
            this.radioResposta[1].checked = true;

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

    // Checa de a palavra ainda não existe
    palavraNaoExiste: function(palavra){
        let naoexiste = true;

        for(let i = 0; i < this.quantidade && naoexiste; i++){
            if(palavra.toLowerCase() == this.listaDeDesafios[i].palavra.toLowerCase())
                naoexiste = false;
        }

        return naoexiste;
    },

    // Mostra ou não o botão para Salvar a fase
    mostraBotaoSalvar: function(){

        if(this.quantidade == 0){
            this.botaoSave.classList.add("ghostElement");
        }else if(this.quantidade == 1){
            this.botaoSave.classList.remove("ghostElement");
        }
    },

    // Remove uma palavra da fase
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

    // Mostra ou esconde os botões de acordo com o que está sendo feito agora
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

    // Limpa os elementos do formulário
    limpaElementos: function(){
        this.palavraTextEdit.value = "";
        this.radioResposta[0].checked = true;
        this.significadoTextEdit.value = "";
        this.dicaTextEdit.value = "";
    },
    serialize: function(obj, prefix){
        var str = [],p;
        for (p in obj) {
            if (obj.hasOwnProperty(p)) {
            var k = prefix ? prefix + "[" + p + "]" : p,
                v = obj[p];
            str.push((v !== null && typeof v === "object") ?
                this.serialize(v, k) :
                encodeURIComponent(k) + "=" + encodeURIComponent(v));
            }
        }
        return str.join("&");
    },

    // Salva os dados de quem está editando e da fase criada, adicionada tudo em um Json
    // e envia tudo para o server side, para ser salvo no BD
    salvarFase: function(){
        console.log("Devo chamar o controller apropriada para salvar a fase da pessoa");
                    
        var url = "/CriarFase/SalvarFaseNormal"; // Url que será enviado
        
        fase = { // Dados da fase
            id: 123,
            usuarioId: 13,
            chave: "key13",
            idTipoFase: 0,
            descricao: "Uma fase",
            desafiosNormal: []
        };

        var listaDeDesafiosParaEnviar = []; // Lista para desafios da fase

        // Add os desafios na lista
        for(var i = 0; i < this.listaDeDesafios.length;i++){
            listaDeDesafiosParaEnviar[i] = new this.desafio(null, this.listaDeDesafios[i].id, this.listaDeDesafios[i].palavra, this.listaDeDesafios[i].eCorreto, this.listaDeDesafios[i].faseId, this.listaDeDesafios[i].significado, this.listaDeDesafios[i].dica);
        }
          
        fase.desafiosNormal = listaDeDesafiosParaEnviar; // add a lista no objeto que será enviado
        
        var json = JSON.stringify(fase);
          
        var xhr = new XMLHttpRequest();
        xhr.open("POST", url, true);
        //xhr.setRequestHeader('Content-type','application/x-www-form-urlencoded');
        xhr.setRequestHeader('Content-type','application/json');
        xhr.onload = function () {
            if (xhr.readyState == 4 && xhr.status == "201") {
                console.log(xhr.responseText);
            } else {
                console.error(xhr.responseText);
            }

            var jsonReceived = JSON.parse(xhr.responseText);
            
            if(jsonReceived.flag)
                window.location.href = '/TaCertoForms/MinhasFases'; // Redireciona
            else
                console.log("Deu ruim no server side");
        }
        xhr.send(json);

    }
}

window.onload = ()=>{
    ScriptsCriarFaseNormal.loadData();
};


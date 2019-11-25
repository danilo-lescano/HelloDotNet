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
    helperText: null,

    // Pega as referências necessárias para o funcionamento das demais funcões
    loadData: function(){
        this.palavraTextEdit = document.getElementById('palavraText'); // EditText da Palavra
        this.radioResposta = document.getElementsByName('alternativaPalavra'); // Radio Button do eCorreto
        this.significadoTextEdit = document.getElementById('textoSignificado'); // EditText do Significado
        this.dicaTextEdit = document.getElementById('textoDica'); // EditText da Dica
        this.palavrasContainer = document.getElementById('palavrasAdicionadas'); // Container das palavras adicionadas

        this.botaoAdd = document.getElementById('botaoAdd'); // Botão para adicionar palavra
        this.botaoEdit = document.getElementById('botaoEdit'); // Botão para editar palavra
        this.botaoSave = document.getElementById('botaoSave'); // Botão para salvar a fase
        this.botaoDeletar = document.getElementById('botaoApagar'); // Botão para deletar a palavra
        
        this.iframe = document.getElementById('normalIframe'); // Iframe do exemplo da fase
        this.palavraTextEdit.focus();  // Limpa os campos do formulário
        this.helperText = document.getElementById('helperText'); // Texto ali da barra superior "Adicionando questões"
    },

    // Adiciona uma palavra na fase atual
    addPalavra: function(){

        let palavra = this.checaPalavra(); // Checa se foi digitado algo

        if(palavra != 0){

            if(this.palavraNaoExiste(this.quantidade, palavra) || this.editando >= 0){
                let cor = this.pegaCor(); // Pega a cor caso a palavra esteja certa ou errada
                let significado = this.significadoTextEdit.value;
                let dica = this.dicaTextEdit.value;

                if(this.editando == -1){ // Não está editando
                    let palavrasContainer = this.palavrasContainer;
                    palavrasContainer.innerHTML += '<div id = "' + this.quantidade+'" class="palavraBox '+cor+'" onclick="ScriptsCriarFaseNormal.carregaParaEditar(this.id)"><h6>'+palavra+'</h6></div>';
                    
                    // Add o novo desafio na lista de desafios
                    this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, this.quantidade-1, palavra, this.correto, -1, significado, dica);

                    // Atualiza o número de desafios atual na tela
                    document.getElementById('numeroDePalavras').innerHTML = this.quantidade;

                    this.mostraToast(2); // Palavra adicionada
                }else{ // Está editando

                    if(this.palavraNaoExiste(this.editando, palavra)){ // Se a palavra digitada ainda náo está na fase atual

                        if(this.listaDeDesafios[this.editando].palavra != palavra){ // Se a palavra foi mudada
                            this.elemento.childNodes[0].innerHTML = palavra;
                            this.listaDeDesafios[this.editando].palavra = palavra; 
                        }

                        if(this.listaDeDesafios[this.editando].eCorreto == true){
                            if(this.correto == false){ // Se eCorreto mudou de true para false
                                this.elemento.classList.remove("green");
                                this.elemento.classList.add("red");
                                this.listaDeDesafios[this.editando].eCorreto = this.correto;
                            }
                        }else{
                            if(this.correto == true){ // Se eCorreto mudou de false para true
                                this.elemento.classList.remove("red");
                                this.elemento.classList.add("green");
                                this.listaDeDesafios[this.editando].eCorreto = this.correto;
                            }
                        }
                            
                        this.listaDeDesafios[this.editando].significado = significado; // Atualiza o significado
                        this.listaDeDesafios[this.editando].dica = dica; // Atualiza a dica

                        this.estaEditando(0); // Muda para não editando
                        this.mostraToast(3); // Palavra editada  
                    }else{
                        this.mostraToast(4); // Palavra já existe  
                        this.palavraTextEdit.focus(); // Dá foco no EditText da Palavra

                        return   
                    }
                }

                this.limpaElementos(); // Limpa os campos do formulário
            }else{
                this.mostraToast(4); // Palavra já existe   
            }
        }else{
            this.mostraToast(1); // Usuário não escreveu uma palavra
        }

        this.palavraTextEdit.focus(); // Dá foco no EditText da Palavra
        this.mostraBotaoSalvar(); // Checa se mostra ou não o botão para salvar a fase
    },

    // Carrega os dados de uma fase inteira para serem editados
    carregarDadosParaEditar: function(json){
        
        this.loadData()

        var str = json;
        var obj = str.replace(/&quot;/g, '"'); // Tira os quot; da string que o Bill Gates colocou no Json
        let jason = JSON.parse(obj); // Transforma a string json em um Json 

        helperText.innerHTML = "<h4>Editando a fase " + jason.Id + "</h4>"; // Carregar o texto helper

        
        this.quantidade = 0
        for(i = 0; i < jason.desafiosNormal.length; i++){ // Guarda os dados do Json na variável lista de desafio local
            this.listaDeDesafios[this.quantidade++] = new this.desafio(this.quantidade -1, jason.desafiosNormal[i].Id, jason.desafiosNormal[i].Palavra, jason.desafiosNormal[i].eCorreto, jason.desafiosNormal[i].FaseId, jason.desafiosNormal[i].Significado, jason.desafiosNormal[i].Dica);
        }

        
        for(i = 0; i < this.quantidade; i++){ // Carregar as palavras adicionadas lá embaixo
            let palavrasContainer = this.palavrasContainer;
            let cor = this.listaDeDesafios[i].eCorreto?"green":"red";
            let palavra = this.listaDeDesafios[i].palavra;

            palavrasContainer.innerHTML += '<div id = "' +i+'" class="palavraBox '+cor+'" onclick="ScriptsCriarFaseNormal.carregaParaEditar(this.id)"><h6>'+palavra+'</h6></div>';
        }
        document.getElementById('numeroDePalavras').innerHTML = this.quantidade;
        this.mostraBotaoSalvar();

    },

    // Checa se uma palavra foi escrita
    checaPalavra: function(){
        let palavra = this.palavraTextEdit.value;
        
        if(palavra != false)
            return palavra;
        return 0;
    },

    /*
     * Mostra toast de acordo com o op
     * op == 1 -> Usuário não digitou uma palavra 
     * op == 2 -> Palavra foi adicionada
     * op == 3 -> Palavra foi modificada
     * op == 4 -> Palavra já foi adicionada
     * op == 5 -> Palavra foi removida
     */
    mostraToast: function(op){
        
        if(op == 1){
            M.toast({html: 'Você precisa digitar uma palavra!', classes: 'rounded red lighten-1 palavraFaltandoModoNormal'});
        }else if(op == 2){
            M.toast({html: 'Palavra adicionada!', classes: 'rounded green lighten-1'});
        }else if(op == 3){
            M.toast({html: 'Palavra modificada!', classes: 'rounded lime'});
        }else if(op == 4){
            M.toast({html: 'Palavra já foi adicionada!', classes: 'rounded red lighten-1'});
        }else if(op == 5){
            M.toast({html: 'Palavra foi removida!', classes: 'rounded red lighten-1'});
        }
    },

    // Retorna a cor do div da palavra para mostrar se ela é certa ou errada
    pegaCor: function(){
        let cor = "green";
        if(this.radioResposta[0].checked){ // Certo checado, logo a palavra deve ficar verde
            this.correto = true;
        }else if(this.radioResposta[1].checked){ // Errado checado, logo a palavra deve ficar vermelha
            cor = "red";
            this.correto = false;
            this.radioResposta[0].checked = true;
        }    

        return cor;
    },

    // Carrega os dados de uma palavra para serem editados
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
        else{
            this.significadoTextEdit.value = elementos.significado;
            this.significadoTextEdit.focus()
        }

        if(elementos.dica == undefined)
            this.dicaTextEdit.value = "";
        else{
            this.dicaTextEdit.value = elementos.dica;
            this.dicaTextEdit.focus()
        }
        this.estaEditando(1); 
    },

    // Troca o texto da palavra da tela de exemplo do jogo pelo texto do campo da palavra
    trocaTextoPalavra: function(palavra){
        let innerDoc = (this.iframe.contentDocument) ? this.iframe.contentDocument : this.iframe.contentWindow.document;
        innerDoc.getElementById('palavra').innerHTML = palavra;
    },

    /* Checa de a palavra ainda não existe
     * index = posicao da palavra na lista de desafios
     * palavra = palavra digitada no momento
     */ 
    palavraNaoExiste: function(index, palavra){
        let naoexiste = true;

        for(let i = 0; i < this.quantidade && naoexiste; i++){ // Checa se a palavra já existe na lista de desafios
            if(palavra.toLowerCase() == this.listaDeDesafios[i].palavra.toLowerCase() && i !== index)
                naoexiste = false;
        }

        return naoexiste;
    },

    // Mostra ou não o botão para Salvar a fase
    mostraBotaoSalvar: function(){

        if(this.quantidade == 0){
            this.botaoSave.classList.add("ghostElement");
        }else if(this.quantidade >= 1){
            this.botaoSave.classList.remove("ghostElement");
        }
    },

    // Remove uma palavra da fase
    apagarPalavra: function(){
        let indexParaApagar = this.editando;

        this.elemento.parentNode.removeChild(this.elemento);

        if(this.editando >= 0 && this.editando < this.quantidade-1){
            for(var i = this.editando; i < this.quantidade-1; ++i){
                var aux = this.listaDeDesafios[i+1];
                this.listaDeDesafios[i] =  new this.desafio(aux.index-1, aux.id-1, aux.palavra, aux.eCorreto, aux.faseId, aux.significado, aux.dica);
                document.getElementById(i+1).id = i;
            }
        }

        this.quantidade -= 1;
        this.listaDeDesafios.length = this.quantidade;
        this.editando = -1;

        this.limpaElementos();
        this.estaEditando(0);
        this.mostraToast(5);
        this.mostraBotaoSalvar();
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



    function limpa_formulario_cep(input_rua, input_bairro, input_cidade, input_estado) {
        // Limpa valores do formulário de cep.
        input_rua.val("");
        input_bairro.val("");
        input_cidade.val("");
        input_estado.val("");
    }
    function popula_cep(input_cep, input_rua, input_bairro, input_cidade, input_estado){
        console.log();
        //Nova variável "cep" somente com dígitos.
        var cep = input_cep.val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if(validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                input_rua.val("...");
                input_bairro.val("...");
                input_cidade.val("...");
                input_estado.val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("//viacep.com.br/ws/"+ cep +"/json/?callback=?", function(dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        input_rua.val(dados.logradouro);
                        input_bairro.val(dados.bairro);
                        input_estado.val(dados.uf).change();
                        input_cidade.val(dados.localidade);

                        console.log(dados.uf);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulario_cep(input_rua, input_bairro, input_cidade, input_estado);
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulario_cep(input_rua, input_bairro, input_cidade, input_estado);
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulario_cep(input_rua, input_bairro, input_cidade, input_estado);
        }    
}

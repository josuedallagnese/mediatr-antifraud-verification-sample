# Exemplo de verificação antifraude em duas etapas:

1 - Primeira etapa: verifica a necessidade de realizar a verificação anti-fraude. Retorno:

```
    OperationId: identificação da operação
    FaceId: se deve ou não realizar a verificação antifraude.
```
    
2 - Segunda etapa: recebe o OperationId para retomar a operação pausada na primeira etapa.

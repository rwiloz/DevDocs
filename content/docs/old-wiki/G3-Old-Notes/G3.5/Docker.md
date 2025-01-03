set no proxy in 
C:\Users\williamesr\.docker\config.json


Install Knative on k8s

 az aks update -n cusdev01 -g Dev_01 --attach-acr cusdev

https://knative.dev/docs/admin/install/serving/install-serving-with-yaml/

kubectl apply -f https://github.com/knative/serving/releases/download/v0.26.0/serving-crds.yaml
kubectl apply -f https://github.com/knative/serving/releases/download/v0.26.0/serving-core.yaml

kubectl apply -f https://github.com/knative/net-kourier/releases/download/v0.26.0/kourier.yaml

$jsonParams='{"data":{"ingress.class":"kourier.ingress.networking.knative.dev"}}' | ConvertTo-Json
kubectl patch configmap/config-network -n knative-serving --type merge -p $jsonParams

kubectl --namespace kourier-system get service kourier


kubectl get pods -n knative-serving

kubectl create secret docker-registry acr-auth --docker-server myexampleacr.azurecr.io --docker-username clientId --docker-password password --docker-email yourEmail


kubectl apply -f gateway.yaml

kubectl patch configmap/config-network -n knative-serving --type merge -p "{\""data\"":{\""k1.g35.dev\"":\""\""}}"


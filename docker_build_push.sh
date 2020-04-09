#!/bin/bash

echo "Please enter a semver version number(0.0.1):"
read version

if [[ -z ${version} ]]; then
  echo "ERROR. Please enter a valid version number"
  exit 1
  else 
  echo "Building and pushing $version"
fi

docker_hub_account="mabhackathon"

echo "Logging into Dockerhub"
docker login -u ${docker_hub_account}
docker build . -t mab-hackathon-api
docker tag mab-hackathon-api ${docker_hub_account}/mab-hackathon-api:latest
docker tag mab-hackathon-api ${docker_hub_account}/mab-hackathon-api:${version}

docker push ${docker_hub_account}/mab-hackathon-api:latest
docker push ${docker_hub_account}/mab-hackathon-api:${version}
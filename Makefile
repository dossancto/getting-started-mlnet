train:
	mlnet classification --dataset "./sentiment labelled sentences/yelp_labelled.txt" --label-col 1 --has-header false --name SentimentModel  --train-time 60

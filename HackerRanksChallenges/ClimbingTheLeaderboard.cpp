#include<bits/stdc++.h>

using namespace std;

struct rankedEntry{
    int score;
    int place;
};

vector<rankedEntry> convertToRE(vector<int> toConvert){
    vector<rankedEntry> converted;
    converted.resize(toConvert.size());
    int currPlace = 0;
    int prevVal = 0;   
    
    for(int i=0; i <toConvert.size(); i++){
        int currVal = toConvert[i];
        if(currVal != prevVal){
            currPlace++;
        }
        rankedEntry temp;
        temp.score = toConvert[i];
        temp.place = currPlace;
        converted[i] = temp;
        prevVal = toConvert[i];

    }
   
    return converted;
}

vector<int> climbingLeaderboard(vector<int> ranked, vector<int> player) {
    vector<int> placeAfterGame;
    placeAfterGame.resize(player.size());
    vector<rankedEntry> rankedAsRE = convertToRE(ranked); ; 
  
    int nextStart = rankedAsRE.size() -1;
    for(int i=0; i < player.size(); i++){
        for(int k=nextStart; k > -1; k -= 1){
            if(rankedAsRE[k].score > player[i]){
                placeAfterGame[i] =  rankedAsRE[k].place +1;
                nextStart = k;
                k -= rankedAsRE.size();
            }
            else if(rankedAsRE[k].score == player[i]){
                placeAfterGame[i] = rankedAsRE[k].place;
                nextStart =k;
                k -= rankedAsRE.size();
            }
            else if(k == 0){
                placeAfterGame[i] = (rankedAsRE[k].place);
            }
    }
    
    }

    return placeAfterGame;
}
void printVetcor(vector<int> toPrint){
    int len =  toPrint.size();
    for(int i=0; i<len; i++){
        std::cout << toPrint[i] <<", ";
    }
}


int main(){
    std::cout << "Test\n";
    vector<int> player = {50,75,110};
    vector<int> ranked= {100,100,90,83,75,65,65,60};
    vector<int> placeAfterGame = climbingLeaderboard(ranked,player);
    printVetcor(placeAfterGame);



}

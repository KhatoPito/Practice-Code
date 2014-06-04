 int gameState(int values[][], int boardSz) {


    boolean colCheckNotRequired[] = new boolean[boardSz];//default is false
    boolean diag1CheckNotRequired = false;
    boolean diag2CheckNotRequired = false;
    boolean allFilled = true;


    int x_count = 0;
    int o_count = 0;
    /* Check rows */
    for (int i = 0; i < boardSz; i++) {
        x_count = o_count = 0;
        for (int j = 0; j < boardSz; j++) 
		{
            if(values[i][j] == x_val)x_count++;
            if(values[i][j] == o_val)o_count++;
            if(values[i][j] == 0)
            {
                colCheckNotRequired[j] = true;
                if(i==j)diag1CheckNotRequired = true;
                if(i + j == boardSz - 1)diag2CheckNotRequired = true;
                allFilled = false;
                //No need check further
                break;
            }
        }
        if(x_count == boardSz)return X_WIN;
        if(o_count == boardSz)return O_WIN;         
    }


    /* check cols */
    for (int i = 0; i < boardSz; i++) {
        x_count = o_count = 0;
        if(colCheckNotRequired[i] == false)
        {
            for (int j = 0; j < boardSz; j++) {
                if(values[j][i] == x_val)x_count++;
                if(values[j][i] == o_val)o_count++;
                //No need check further
                if(values[i][j] == 0)break;
            }
            if(x_count == boardSz)return X_WIN;
            if(o_count == boardSz)return O_WIN;
        }
    }

    x_count = o_count = 0;
    /* check diagonal 1 */
    if(diag1CheckNotRequired == false)
    {
        for (int i = 0; i < boardSz; i++) {
            if(values[i][i] == x_val)x_count++;
            if(values[i][i] == o_val)o_count++;
            if(values[i][i] == 0)break;
        }
        if(x_count == boardSz)return X_WIN;
        if(o_count == boardSz)return O_WIN;
    }

    x_count = o_count = 0;
    /* check diagonal 2 */
    if( diag2CheckNotRequired == false)
    {
        for (int i = boardSz - 1,j = 0; i >= 0 && j < boardSz; i--,j++) {
            if(values[j][i] == x_val)x_count++;
            if(values[j][i] == o_val)o_count++;
            if(values[j][i] == 0)break;
        }
        if(x_count == boardSz)return X_WIN;
        if(o_count == boardSz)return O_WIN;
        x_count = o_count = 0;
    }

    if( allFilled == true)
    {
        for (int i = 0; i < boardSz; i++) {
            for (int j = 0; j < boardSz; j++) {
                if (values[i][j] == 0) {
                    allFilled = false;
                    break;
                }
            }

            if (allFilled == false) {
                break;
            }
        }
    }

    if (allFilled)
        return DRAW;

    return INPROGRESS;
}
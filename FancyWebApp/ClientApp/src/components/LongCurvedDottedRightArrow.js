// @ts-nocheck
import React from 'react'
import {
    makeStyles,
} from "@material-ui/core";

const useStyles = makeStyles({
    arrowIcon: {
        marginLeft: "-40px",
        marginRight: "-40px",
        marginTop: "-50px",
        marginBottom: "-50px",
        transform: "translate(0, -35px) rotate(155deg)",
    }
});

export default function LongCurvedDottedRightArrow() {
    const classes = useStyles();
  return (
    <img className={classes.arrowIcon} alt="right arrow" src={require('../assets/curved_arrow6.png')} height="300px" width="300px"></img>
  )
}
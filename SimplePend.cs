using System;

namespace Sim
{
    public class SimplePend
    {
        //////////////////////////////////////////////////////////////////////
        // Define Variables                                                
        //////////////////////////////////////////////////////////////////////
        private double len  = 1.1;
        private double g = 9.81;
        private double k1, k2, k3, k4, m1, m2, m3, m4, i1, i2,i3;
        private double y = 1.0;
        private double u = 0.0;
        
        //////////////////////////////////////////////////////////////////////
        // Constructor                                              
        // ////////////////////////////////////////////////////////////////////// 
        
        // public SimplePend()
        // {

        // }

        //////////////////////////////////////////////////////////////////////
        // step: perform one intergration step via Eulers Method                                               
        //////////////////////////////////////////////////////////////////////
        public void step (double dt)
        {
            for(int i=0 ; i<1 ; ++i)
            {
                m1 = dt * ( u );
                k1 = dt * ( -g/len*Math.Sin(y) );


                m2 = dt * ( u + k1/2);
                i1 = y + ( m1/2 );
                k2 = dt * (-g/len*Math.Sin(i1) ) ;


                m3 = dt * ( u + k2/2 );
                i2 = y + ( m2/2 );
                k3 = dt * ( -g/len*Math.Sin(i2) );


                m4 = dt * ( u + k3);
                i3 = y + m3;
                k4 = dt * ( -g/len*Math.Sin(i3) );
                

                u = u + ((k1 + 2*k2 + 2*k3 + k4) / 6.0);
                y = y + ((m1 + 2*m2 + 2*m3 + m4) / 6.0);
            }
        }

        //////////////////////////////////////////////////////////////////////
        // Getters and Setters                                                
        //////////////////////////////////////////////////////////////////////
        public double L
        {
            get 
            {
                return(len);
            }
            set 
            {
                if(value>0.0)
                len = value;
            }
        }
        
        public double G
        {
            get 
            {
                return(g);
            }
            set 
            {
                if(value>=0.0)
                g = value;
            }
        }

         public double RK4_theta
        {
            get 
            {
                return(y);
            }
            set 
            {
                y = value; 
            }
        }

        public double RK4_thetaDot
        {
            get 
            {
                return(u);
            }
            set 
            {
                u = value; 
            }
        }
    }
}
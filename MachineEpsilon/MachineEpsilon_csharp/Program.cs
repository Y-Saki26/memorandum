

Func.Func.CheckMachineEps();
Func.Func.CheckMachineEps_Diff();

namespace Func
{
    static class Func
    {
        public static void CheckMachineEps() {
            Console.WriteLine("min x s.t. one != x; eps = x-one: Binary Search");
            Console.WriteLine($"{"Type",-25:G}: {"Machine EPS",13:G}, {"EPS=2^-n",10:G}, {"Type.Epsilon"}");
            // UnityEngine.Vector2
            {
                UnityEngine.Vector2 one = UnityEngine.Vector2.right,
                    lower = UnityEngine.Vector2.right,
                    upper = UnityEngine.Vector2.right * 2,
                    middle = (lower + upper) / 2,
                    x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = (x - one).x;
                Console.WriteLine($"{"`UnityEngine.Vector2`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}");
            }

            // UnityEngine.Vector3
            {
                UnityEngine.Vector3 one = UnityEngine.Vector3.right,
                    lower = UnityEngine.Vector3.right,
                    upper = UnityEngine.Vector3.right * 2,
                    middle = (lower + upper) / 2,
                    x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = (x - one).x;
                Console.WriteLine($"{"`UnityEngine.Vector3`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}");
            }

            // UnityEngine.Vector2 .Equals
            {
                UnityEngine.Vector2 one = UnityEngine.Vector2.right,
                    lower = UnityEngine.Vector2.right,
                    upper = UnityEngine.Vector2.right * 2,
                    middle = (lower + upper) / 2,
                    x = middle;
                while(middle.x != lower.x && middle.x != upper.x) {
                    x = middle;
                    if(one.Equals(middle)) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = (x - one).x;
                Console.WriteLine($"{"`UE.Vector2 .Equals`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}");
            }

            // System.Numerics.Vector2
            {
                System.Numerics.Vector2 one = System.Numerics.Vector2.UnitX,
                    lower = System.Numerics.Vector2.UnitX,
                    upper = System.Numerics.Vector2.UnitX * 2,
                    middle = (lower + upper) / 2,
                    x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = (x - one).X;
                Console.WriteLine($"{"`System.Numerics.Vector2`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}");
            }

            // System.Numerics.Vector2
            {
                System.Numerics.Vector3 one = System.Numerics.Vector3.UnitX,
                    lower = System.Numerics.Vector3.UnitX,
                    upper = System.Numerics.Vector3.UnitX * 2,
                    middle = (lower + upper) / 2,
                    x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = (x - one).X;
                Console.WriteLine($"{"`System.Numerics.Vector3`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}");
            }

            // float
            {
                float one = 1f, lower = 1f, upper = 2f, middle = (lower + upper) / 2, x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = x - one;
                Console.WriteLine($"{"`float`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}, {Single.Epsilon,-14:E}");
            }

            // float - div2
            {
                float one = 1f, x = 2f, eps = x;
                while(one != x) {
                    eps = x;
                    x = (one + x) / 2;
                }
                eps -= one;
                Console.WriteLine($"{"`float` div2",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}, {Single.Epsilon,-14:E}");
            }

            // double
            {
                double one = 1d, lower = 1d, upper = 2d, middle = (lower + upper) / 2, x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = x - one;
                Console.WriteLine($"{"`float`",-25:G}: {eps:E}, {-Math.Log2(eps),10:F}, {Double.Epsilon,-14:E}");
            }

            // half
            {

                Half one = (Half)1d, lower = (Half)1d, upper = (Half)2d,
                    middle = (Half)(((double)lower + (double)upper) / 2),
                    x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (Half)(((double)lower + (double)upper) / 2);
                }
                var eps = (Half)((double)x - (double)one);
                Console.WriteLine($"{"`Half`",-25:G}: {eps:E}, {-Math.Log2((double)eps),10:F}, {Half.Epsilon,-14:E}");
            }

            // decimal
            {
                decimal one = 1m, lower = 1m, upper = 2m, middle = (lower + upper) / 2, x = middle;
                while(middle != lower && middle != upper) {
                    x = middle;
                    if(one == middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                var eps = x - one;
                Console.WriteLine($"{"`decimal`",-25:G}: {eps:E}, {-Math.Log2((double)eps),10:F}");
            }
        }
        public static void CheckMachineEps_Diff() {
            Console.WriteLine("min eps s.t. one != eps + one: Binary Search");
            Console.WriteLine($"{"Type",-25:G}: {"Machine EPS",13:G}, {"EPS=2^-n",10:G}, {"Type.Epsilon"}");
            // float
            {
                var one = 1f;
                var lower = 0f;
                var upper = 1f;
                var middle = (lower + upper) / 2;
                while(lower != middle && upper != middle) {
                    if(one == one + middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                Console.WriteLine($"{"`float`",-25}: {middle:E}, {-Math.Log2((double)middle),10:F}, {Single.Epsilon,-14:E}");
            }

            // double
            {
                var one = 1d;
                var lower = 0d;
                var upper = 1d;
                var middle = (lower + upper) / 2;
                while(lower != middle && upper != middle) {
                    if(one == one + middle) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (lower + upper) / 2;
                }
                Console.WriteLine($"{"`double`",-25}: {middle:E}, {-Math.Log2(middle),10:F}, {Double.Epsilon,-14:E}");
            }

            // half
            {
                var one = (Half)1;
                var lower = (Half)0;
                var upper = (Half)1;
                var middle = (Half)(((float)lower + (float)upper) / 2);
                while(lower != middle && upper != middle) {
                    if(one == (Half)((float)one + (float)middle)) {
                        lower = middle;
                    } else {
                        upper = middle;
                    }
                    middle = (Half)(((float)lower + (float)upper) / 2);
                }
                Console.WriteLine($"{"`Half`",-25}: {middle:E}, {-Math.Log2((double)middle),10:F}, {Half.Epsilon,-14:E}");
            }
        }
    }
}
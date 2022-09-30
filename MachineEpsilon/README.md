# MachineEpsilon

Python と C# で計算機イプシロンを求める計算を行う．

## 概要

計算機イプシロンとは「浮動小数点数において、「1より大きい最小の数」と1との差」([計算機イプシロン - Wikipedia](https://ja.wikipedia.org/wiki/%E8%A8%88%E7%AE%97%E6%A9%9F%E3%82%A4%E3%83%97%E3%82%B7%E3%83%AD%E3%83%B3))である．  
「1より大きい最小の数」は2進数で $1.00\dots01_{(2)}$ と表せるので，計算機イプシロンは浮動小数点数の仮数部のビット数を $b$ として $2^{-b}$ である．

```py
import math

def machine_eps(one):
    one_eps = one + one
    for b in range(10**3):
        if one == (one + one_eps) / 2:
            eps = one_eps - one
            return eps
        one_eps = (one + one_eps) / 2

eps = machine_eps(1)
print(f"{eps}, 2^{math.log2(eps)}")
# => 2.220446049250313e-16, 2^-52.0
```

Python の `float` はIEEE 754 倍精度なので仮数部は52bitであり， $2^{52}$ が計算機イプシロンである．
C# でも `double` で同様の結果となる．

## システムから計算機イプシロンを得る方法の比較

Pythonではシステム定数として

```py
import sys
sys.float_info.epsilon #=> 2.220446049250313e-16
```

のように得られるが，C# では標準ライブラリに該当するフィールドは用意されていない．
`System.Single` や `System.Double` には `Epsilon` というフィールドが存在する([※](https://learn.microsoft.com/ja-jp/dotnet/api/system.double.epsilon?view=net-6.0))が，これはゼロより大きい最小の値を表す．Python では `sys.float_info.min` で得られる "The minimum positive normalized value" に相当する．
これは倍精度で `4.94065645841247E-324` と，計算機イプシロンとは全く異なる値なので注意が必要である．

## 異なる定義の比較

計算機イプシロンを「$1+x\neq 1$ となる最小の $x$」と同値であるかのような定義や説明がされることがあるが，実際は加算結果が桁落ちした際の丸め処理によっては一致しない．  
実際，Python や C# でこの定義に基づいて計算を行うと正しい値の半分になる．  
参考：[計算機イプシロンのこと - 再帰の反復blog](https://lemniscus.hatenablog.com/entry/20090816/1250441897)

```py
def machine_eps_diff(one):
    lower = one * 0
    upper = one
    middle = (lower + upper) / 2
    while lower!=middle!=upper:
        eps = middle
        if one == one + eps:
            lower = middle
        else:
            upper = middle
        middle = (lower + upper) / 2
    return eps

eps = machine_eps_diff(1)
print(f"{eps}, 2^{math.log2(eps)}")
#=> 1.1102230246251568e-16, 2^-53.0
```

## UnityEngine.Vector2 の計算精度

C# の `UnityEngine.Vector2` を用いて同様の計算を行おうとすると，計算機イプシロンは $2^{-16}$ であるとの結果が得られる．

```csharp
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
//=> `UnityEngine.Vector2`    : 1.525879E-005,      16.00
```

`UnityEngine.Vector2` のフィールドは単精度浮動小数点数であるので $2^{-23}$ であるべきである．
これは `UnityEngine.Vector2` の等号演算子 `==` が相対誤差 1e-5 の範囲では一致とされるようにオーバーライドされている([参照](https://docs.unity3d.com/ja/current/ScriptReference/Vector2-operator_eq.html))からであり， `Equals` メソッドを用いれば `float` と同じ計算機イプシロンが得られる．

```csharp
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
//=> `UE.Vector2 .Equals`     : 1.192093E-007,      23.00
```

## その他

その他計算の詳細は Python は [MachineEpsilon.ipynb](https://github.com/Y-Saki26/memorandum/blob/main/MachineEpsilon/MachineEpsilon.ipynb) ，C# はソースコードが [MachineEpsilon_csharp/Program.cs](https://github.com/Y-Saki26/memorandum/blob/main/MachineEpsilon/MachineEpsilon_csharp/Program.cs) ，結果は [MachineEpsilon_csharp_output.txt](https://github.com/Y-Saki26/memorandum/blob/main/MachineEpsilon/MachineEpsilon_csharp_output.txt) を参照．

Python では上記のほか，numpyを用いた半精度～4倍精度小数で同様の計算・1以外の値に対する相対誤差評価を行う場合の最小誤差の評価を行っている．
C# でも `float`, `double` を始めとした複数の結果を記載．
